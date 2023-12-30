using System;
using System.Collections.Generic;

namespace ch07_Set
{
    public class SetTest
    {
        public void Test()
        {
            LogonTest();
        }

        private void init()
        {
            HashSet<string> colors = new HashSet<string>();
            colors.Add("green");
            Console.WriteLine($"{colors.Count}");
            colors.Add("yellow");
            Console.WriteLine($"{colors.Count}");
            colors.Add("red");
            Console.WriteLine($"{colors.Count}");
            colors.Add("red");
            Console.WriteLine($"{colors.Count}");
            colors.Add("blue");
            Console.WriteLine($"{colors.Count}");
        }

        #region Logon User demo
        HashSet<User> _users;
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
            _users = new HashSet<User>();
        }

        //private bool CanAddUser(User user)
        //{
        //    return _users.Add(user);
        //}

        private bool UserAuthenticated(User user)
        {
            if (_users.Count < 3)
            {
                if (_users.Add(user))
                {
                    Console.WriteLine($"Length after adding user {user.Id}: {_users.Count}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"{user.Id} existing in set already.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Set is full");
                return false;
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

        #region playlist

        class PlaylistSet
        {
            HashSet<Song> _songs;
            public Int16 capacity { get; private set; }
            public bool premiumUser { get; private set; }
            public bool isEmpty
            {
                get
                {
                    return _songs.Count == 0;
                }
            }
            public bool isFull
            {
                get
                {
                    if (premiumUser)
                    {
                        return false;
                    }
                    else
                    {
                        return _songs.Count == capacity;
                    }
                }
            }

            public PlaylistSet(bool premiumUser, Int16 capacity)
            {
                _songs = new HashSet<Song>();
                premiumUser = premiumUser;
                capacity = capacity;
            }

            public bool AddSong(Song song)
            {
                if (!isFull)
                {
                    return _songs.Add(song);
                }
                return false;
            }

            public bool RemoveSong(Song song)
            {
                return _songs.Remove(song);
            }

            public void MergeWithPlaylist(HashSet<Song> playlist)
            {
                _songs.UnionWith(playlist);
            }

            public HashSet<Song> FindSharedSongsInPlaylist(HashSet<Song> playlist)
            {
                HashSet<Song> songCopy = new HashSet<Song>(_songs);
                songCopy.IntersectWith(playlist);
                return songCopy;
            }

            public HashSet<Song> FindUniqueSongs(HashSet<Song> playlist)
            {
                HashSet<Song> songsCopy = new HashSet<Song>(_songs);
                songsCopy.ExceptWith(playlist);
                return songsCopy;
            }

            public bool IsSubset(HashSet<Song> playlist)
            {
                return _songs.IsSubsetOf(playlist);
            }

            public bool IsSuperset(HashSet<Song> playlist)
            {
                return _songs.IsSupersetOf(playlist);
            }

            public int TotalSongs() 
            {
                return _songs.Count;
            }
        }

        class Song
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        #endregion
    }

}
