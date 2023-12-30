using System;

namespace ch02_Array
{
    public class ArrayTest
    {
        User[] _users;
        public void Test()
        {
            LogonTest();
            linearSearchTest();
            ArrayType();
        }

        #region Logon User demo
        private void LogonTest()
        {
            LoggedInUserArray();
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
        private void LoggedInUserArray()
        {
            User[] users= new User[0];
            _users = users;
        }

        private bool CanAddUser(User user)
        {
            bool containsUser = false;
            foreach (var u in _users)
            {
                if(user == u)
                {
                    containsUser = true;
                    break;
                }
            }

            if(containsUser)
            {
                return false;
            }
            else
            {
                if (_users.Length >= 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void UserAuthenticated(User user)
        {
            if (CanAddUser(user))
            {
                Array.Resize(ref _users, _users.Length + 1);
                _users[_users.Length - 1] = user;
                Console.WriteLine($"Length after adding user {user.Id}: {_users.Length}");
            }
        }

        private void UserLoggedOut(User user)
        {
            int index = Array.IndexOf(_users, user);
            if (index > -1)
            {
                User[] newUsers = new User[_users.Length - 1];
                for (int i = 0, j = 0; i < newUsers.Length - 1; i++, j++)
                {
                    if (i == index)
                    {
                        j++;
                    }
                    newUsers[i] = _users[j];
                }
                _users = newUsers;
            }
            else
            {
                Console.WriteLine($"User {user.Id} not found.");
            }
            Console.WriteLine($"Length after logging out user {user.Id}: {_users.Length}");
        }

        class User
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public DateTime LoginOn { get; set; }

        }
        #endregion

        #region Adv topic
        private void linearSearchTest()
        {
            var user3 = new User
            {
                Id = 3,
                UserName = "Name 3",
                LoginOn = DateTime.Now
            };
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == user3)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        private void ArrayType()
        {
            int[] intArray = { 1,2,3,4,5 };
            Console.WriteLine(string.Join(", ", intArray).Trim().Trim(new [] { ',' }));

            User[] users = new User[_users.Length];
            for (int i = 0; i < _users.Length; i++)
            {
                users[i] = _users[i];
            }
            Console.WriteLine($"Users.Length: {users.Length}");

            object[] objs = new object[_users.Length];
            for (int i = 0; i < _users.Length; i++)
            {
                objs[i] = _users[i];
            }
            Console.WriteLine($"objects.Length: {objs.Length}");

            // init: Length=6
            int[,] twoD_Array = new int[2, 3];
            // assign
            twoD_Array[1, 2] = 12;
            // read
            int x2y3 = twoD_Array[1, 2];
            Console.WriteLine($"twoD_Array.Length: {twoD_Array.Length}; twoD_Array[1,2]:{twoD_Array[1, 2]}; x2y3: {x2y3}");

            // init: Length=24
            int[,,] threeD_Array = new int[2, 3, 4];
            // assign
            threeD_Array[1, 2, 3] = 234;
            // read
            int x2y3z4 = threeD_Array[1, 2, 3];
            Console.WriteLine($"threeD_Array.Length: {threeD_Array.Length}; threeD_Array[1, 2, 3]:{threeD_Array[1, 2, 3]}; x2y3z4: {x2y3z4}");
        }
        #endregion
    }
}
