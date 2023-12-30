using System;
using System.Collections;
using System.Collections.Generic;

namespace ch03_List
{
    public class ListTest
    {
        public void Test()
        {
            LogonTest();
        }


        private void init()
        {
            var arrayList = new ArrayList();
            var anotherArrayList = new List<string>();

            var linkedList = new LinkedList<string>();
        }

        #region Logon User demo
        List<User> _users;
        private void LogonTest()
        {
            LoggedInUserList();
            var user1 = new User
            {
                Id = 1,
                UserName = "Name 1",
                LoginOn = DateTime.Now
            };
            UserAuthenticated(user1);
            var user2 = new User
            {
                Id = 2,
                UserName = "Name 2",
                LoginOn = DateTime.Now
            };
            UserAuthenticated(user2);
            var user3 = new User
            {
                Id = 3,
                UserName = "Name 3",
                LoginOn = DateTime.Now
            };
            UserAuthenticated(user3);

            UserLoggedOut(user2);
            UserAuthenticated(user3);
        }
        private void LoggedInUserList()
        {
            _users = new List<User>();
        }

        private bool CanAddUser(User user)
        {
            if (_users.Contains(user) || _users.Count >= 2)
                return false;
            else 
                return true;
        }

        private void UserAuthenticated(User user)
        {
            if (CanAddUser(user))
            {
                _users.Add(user);
                Console.WriteLine($"Length after adding user {user.Id}: {_users.Count}");
            }
        }

        private void UserLoggedOut(User user)
        {
            _users.Remove(user);
            Console.WriteLine($"Length after logging out user {user.Id}: {_users.Count}");
        }

        class User
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public DateTime LoginOn { get; set; }

        }
        #endregion

        #region Way point
        LinkedList<Waypoint> route = new LinkedList<Waypoint>();
        LinkedListNode<Waypoint> current;

        /// <summary>
        /// O(n)
        /// </summary>
        /// <returns></returns>
        public void AddWaypoints(List<Waypoint> waypoints)
        {
            foreach (var wp in waypoints)
            {
                route.AddLast(wp);
            }
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <returns></returns>
        public bool RemoveWaypoint(Waypoint waypoint)
        {
            return route.Remove(waypoint);
        }

        /// <summary>
        /// O(n+i)
        /// </summary>
        /// <returns></returns>
        public void InsertWaypointsBefore(List<Waypoint> waypoints, Waypoint before)
        {
            LinkedListNode<Waypoint> node = route.Find(before);
            if(node != null)
            {
                foreach (var wp in waypoints)
                {
                    route.AddBefore(node, wp);
                }
            }
            else
            {
                AddWaypoints(waypoints);
            }
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public bool StartRoute()
        {
            if (route.Count > 1)
            {
                current = StartingLine();
                return MoveToNextWaypoint();
            }
            return false;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public bool MoveToNextWaypoint()
        {
            if (current != null)
            {
                current.Value.DeactiveWaypoint();
                if (current != FinishLine())
                {
                    current = current.Next;
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public bool MoveToPreviousWaypoint()
        {
            if(current !=null && current != StartingLine())
            {
                current = current.Previous;
                current.Value.ReactiveWaypoint();
                return true;
            }

            return false;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public LinkedListNode<Waypoint> StartingLine()
        {
            return route.First;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public LinkedListNode<Waypoint> FinishLine()
        {
            return route.Last;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        public LinkedListNode<Waypoint> CurrentPosition()
        {
            return current;
        }

        public class Waypoint
        {
            private int _id;
            private Waypoint Previous;
            private Waypoint Next;
            private int X;
            private int Y;
            public Waypoint(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void PrevPoint(int pre)
            {
                _id= pre;
            }

            public void NextPoint(int next)
            {
                _id= next;
            }

            public void DeactiveWaypoint()
            {
                Console.WriteLine("DeactiveWaypoint");
            }

            public void ReactiveWaypoint()
            {
                Console.WriteLine("ReactiveWaypoint");
            }
        }
        #endregion
    }
}
