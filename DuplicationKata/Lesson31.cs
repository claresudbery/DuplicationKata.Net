namespace DuplicationKata
{
    public class Lesson31 : Song
    {
        public void SingSong(int style, string[] names)
        {
            switch (style)
            {
                case 1:
                    {
                        SingRefrain(names, 
                            true, 
                            "L", 
                            name => "Hip Hip Hooray! For ");
                    }
                    break;
                case 2:
                    {
                        SingRefrain(names, 
                            true, 
                            "a", 
                            name => name.ToUpperInvariant() + "! Yay ");
                    }
                    break;
                case 3:
                    {
                        SingRefrain(names, 
                            false, 
                            "Don't care", 
                            name => "No special greeting");
                    }
                    break;
            }
        }

        private void SingRefrain(string[] names, 
            string nameStart, 
            Func<string, string> specialGreetingFunc, 
            bool checkNameStart)
        {
            foreach (var name in names)
            {
                if (checkNameStart && name.StartsWith(nameStart))
                {
                    Sing(specialGreetingFunc(name) + name);
                }
                else
                {
                    Sing("Hello " + name + ", it's nice to meet you.");
                }
            }
        }
    }
}