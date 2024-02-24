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
                        SingRefrain(names, false);
                    }
                    break;
            }
        }

        private void SingRefrain(string[] names, 
            bool checkNameStart, 
            string nameStart = "Irrelevant", 
            Func<string, string>? specialGreetingFunc = null)
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