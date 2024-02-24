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
                            "L", 
                            name => "Hip Hip Hooray! For ", 
                            true);
                    }
                    break;
                case 2:
                    {
                        SingRefrain(names, 
                            "a", 
                            name => name.ToUpperInvariant() + "! Yay ", 
                            true);
                    }
                    break;
                case 3:
                    {
                        SingRefrain(names, "Don't care");
                    }
                    break;
            }
        }

        private void SingRefrain(string[] names, 
            string nameStart, 
            Func<string, string>? specialGreetingFunc = null, 
            bool checkNameStart = false)
        {
            foreach (var name in names)
            {
                if (checkNameStart && name.StartsWith(nameStart))
                {
                    Sing(specialGreetingFunc?.Invoke(name) + name);
                }
                else
                {
                    Sing("Hello " + name + ", it's nice to meet you.");
                }
            }
        }
    }
}