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
                        SingRefrain(names, false);
                    }
                    break;
            }
        }

        private void SingRefrain(string[] names, 
            bool checkNameStart, 
            string nameStart = "Irrelevant", 
            string specialGreeting = "No special greeting")
        {
            foreach (var name in names)
            {
                if (checkNameStart && name.StartsWith(nameStart))
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