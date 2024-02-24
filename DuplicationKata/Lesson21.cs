namespace DuplicationKata
{
    public class Lesson21 : Song
    {
        public void SingSong(int style, string[] names)
        {
            switch (style)
            {
                case 1:
                    {
                        var dummyBool = true;
                        var nameStart = "L";
                        var specialGreeting = "Hip Hip Hooray! For ";
                        SingRefrain(names, dummyBool, nameStart, specialGreeting);
                    }

                    break;
                case 2:
                    {
                        var dummyBool = true;
                        var specialGreeting = "Say yeah! Say yo! Say ";
                        var nameStart = "Sam";
                        SingRefrain2(names, dummyBool, nameStart, specialGreeting);
                    }

                    break;
                case 3:
                    {
                        var dummyBool = false;
                        var nameStart = "L";
                        var specialGreeting = "Hip Hip Hooray! For ";
                        SingRefrain3(names, dummyBool, nameStart, specialGreeting);
                    }
                    break;
            }
        }

        private void SingRefrain3(string[] names, bool dummyBool, string nameStart, string specialGreeting)
        {
            foreach (var name in names)
            {
                if (dummyBool && name.StartsWith(nameStart))
                {
                    Sing(specialGreeting + name);
                }
                else
                {
                    Sing("Hello " + name + ", it's nice to meet you.");
                }
            }
        }

        private void SingRefrain2(string[] names, bool dummyBool, string nameStart, string specialGreeting)
        {
            foreach (var name in names)
            {
                if (dummyBool && name.StartsWith(nameStart))
                {
                    Sing(specialGreeting + name);
                }
                else
                {
                    Sing("Hello " + name + ", it's nice to meet you.");
                }
            }
        }

        private void SingRefrain(string[] names, bool dummyBool, string nameStart, string specialGreeting)
        {
            foreach (var name in names)
            {
                if (dummyBool && name.StartsWith(nameStart))
                {
                    Sing(specialGreeting + name);
                }
                else
                {
                    Sing("Hello " + name + ", it's nice to meet you.");
                }
            }
        }
    }
}