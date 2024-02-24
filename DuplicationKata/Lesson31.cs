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
                        var nameStart = "L";
                        var checkNameStart = true;
                        Func<string, string> specialGreetingFunc = name => "Hip Hip Hooray! For ";
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
                    break;
                case 2:
                    {
                        var nameStart = "a";
                        var checkNameStart = true;
                        Func<string, string> specialGreetingFunc = name => name.ToUpperInvariant() + "! Yay ";
                        foreach (var name in names)
                        {
                            if (checkNameStart && name.Contains(nameStart))
                            {
                                Sing(specialGreetingFunc(name) + name + "!");
                            }
                            else
                            {
                                Sing("Hello " + name + ", it's nice to meet you.");
                            }
                        }
                    }
                    break;
                case 3:
                {
                    var nameStart = "Don't care";
                    var checkNameStart = false;
                    Func<string, string> specialGreetingFunc = name => "No special greeting";
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
                    break;
            }
        }
    }
}