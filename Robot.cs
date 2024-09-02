using System;
using SplashKitSDK;

public abstract class Robot
{
    public double X { get; private set; }

    public double Y { get; private set; }

    public Vector2D Velocity { get; private set; }

    public Color MainColor;

    protected Window gameWindow;

    public Circle CollisionCircle
    {
        get
        {
            return SplashKit.CircleAt(X, Y, 20);
        }
    }

    public int Height
    {
        get
        {
            return 50;
        }
    }

    public int Width
    {
        get
        {
            return 50;
        }
    }

    public Robot(Window gameWindow, Player player)
    {
        if (SplashKit.Rnd() < 0.5)
        {
            X = SplashKit.Rnd(gameWindow.Width);
            if (SplashKit.Rnd() < 0.5)
            {
                Y = -Height;
            }
            else
            {
                Y = gameWindow.Height;
            }
        }
        else
        {
            Y = SplashKit.Rnd(gameWindow.Height);
            if (SplashKit.Rnd() < 0.5)
            {
                X = -Width;
            }
            else
            {
                X = gameWindow.Width;
            }
        }

        const int SPEED = 4;

        // Get a Point for the Robot 
        Point2D fromPt = new Point2D()
        {
            X = X,
            Y = Y
        };

        // Get Point for the Player
        Point2D toPt = new Point2D()
        {
            X = player.X,
            Y = player.Y
        };

        // Calulate the direction to head.
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        Velocity = SplashKit.VectorMultiply(dir, SPEED);

        this.MainColor = Color.RandomRGB(200);
        this.gameWindow = gameWindow;
    }

    public abstract void Draw();


    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }

    public bool IsOffScreen(Window screen)
    {
        if (X < -Width)
        {
            return true;
        }
        else if (X > screen.Width)
        {
            return true;
        }
        else if (Y < -Height)
        {
            return true;
        }
        else if (Y > screen.Height)
        {
            return true;
        }
        return false;

    }

}
public class Boxy : Robot
{

    public Boxy(Window gameWindow, Player player) : base(gameWindow, player)
    {
        // Boxy-specific constructor code, if needed
    }

    public override void Draw()
    {
        // Boxy-specific drawing code
        double leftX, rightX;
        double eyeY, mouthY;

        leftX = X + 12;

        rightX = X + 27;

        eyeY = Y + 10;
        mouthY = Y + 30;

        this.gameWindow.FillRectangle(Color.Blue, X, Y, 50, 50);
        this.gameWindow.FillRectangle(MainColor, leftX, eyeY, 10, 10);
        this.gameWindow.FillRectangle(MainColor, rightX, eyeY, 10, 10);
        this.gameWindow.FillRectangle(MainColor, leftX, mouthY, 25, 10);
        this.gameWindow.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);

    }
}

public class Roundy : Robot
{
    public Roundy(Window gameWindow, Player player) : base(gameWindow, player)
    {
        // Roundy-specific constructor code, if needed
    }

    public override void Draw()
    {
        double leftX, midX, rightX;
        double midY, eyeY, mouthY;

        leftX = X + 17;
        midX = X + 25;
        rightX = X + 33;

        midY = Y + 25;
        eyeY = Y + 20;
        mouthY = Y + 35;

        this.gameWindow.FillCircle(Color.White, midX, midY, 25);
        this.gameWindow.DrawCircle(Color.Gray, midX, midY, 25);
        this.gameWindow.FillCircle(MainColor, leftX, eyeY, 5);
        this.gameWindow.FillCircle(MainColor, rightX, eyeY, 5);
        this.gameWindow.FillEllipse(Color.Gray, X, eyeY, 50, 30);
        this.gameWindow.DrawLine(Color.Black, X, mouthY, X + 50, Y + 35);
        // Roundy-specific drawing code
    }
}

