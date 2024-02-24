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
                        SingRefrain(names, true, "L", "Hip Hip Hooray! For ");
                    }

                    break;
                case 2:
                    {
                        SingRefrain(names, true, "Sam", "Say yeah! Say yo! Say ");
                    }

                    break;
                case 3:
                    {
                        SingRefrain(names, false, "L", "Hip Hip Hooray! For ");
                    }
                    break;
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