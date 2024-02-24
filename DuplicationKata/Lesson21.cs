namespace DuplicationKata
{
    public class Lesson21 : Song
    {
        public void SingSong(int style, string[] names)
        {
            switch (style)
            {
                case 1:
                    
                    foreach (var name in names)
                    {
                        var dummyBool = true;
                        var nameStart = "L";
                        var specialGreeting = "Hip Hip Hooray! For ";
                        if (dummyBool && name.StartsWith(nameStart))
                        {
                            Sing(specialGreeting + name);
                        }
                        else
                        {
                            Sing("Hello " + name + ", it's nice to meet you.");
                        }
                    }
                    
                    break;
                case 2:
                    
                    foreach (var name in names)
                    {
                        var dummyBool = true;
                        var specialGreeting = "Say yeah! Say yo! Say ";
                        var nameStart = "Sam";
                        if (dummyBool && name.StartsWith(nameStart))
                        {
                            Sing(specialGreeting + name);
                        }
                        else
                        {
                            Sing("Hello " + name + ", it's nice to meet you.");
                        }
                    }
                    
                    break;
                case 3:
                    
                    foreach (var name in names)
                    {
                        var dummyBool = false;
                        var nameStart = "L";
                        var specialGreeting = "Hip Hip Hooray! For ";
                        if (dummyBool && name.StartsWith(nameStart))
                        {
                            Sing(specialGreeting + name);
                        }
                        else
                        {
                            Sing("Hello " + name + ", it's nice to meet you.");
                        }
                    }
                    
                    break;
            }
        }
    }
}