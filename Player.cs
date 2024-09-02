using System;
using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap;
    private Bitmap _HeartBitmap;
    private int _Lives;
    private int _Score;
    private SplashKitSDK.Timer _ScoreTimer;
    
    public List<Bullet> _bullets;

    public double X { get; private set; }
    public double Y { get; private set; }

    public int Lives
    {
        get { return _Lives; }
    }

    public int Score
    {
        get { return _Score; }
    }

    public int Width
    {
        get { return _PlayerBitmap.Width; }
    }

    public int Height
    {
        get { return _PlayerBitmap.Height; }
    }

    public bool Quit { get; private set; }

    private Window gameWindow;

    public Player(Window gameWindow)
    {
        _PlayerBitmap = new Bitmap("img1", "Player.png");
        X = (gameWindow.Width - Width) / 2;
        Y = (gameWindow.Height - Height) / 2;
        _Lives = 5;
        _Score = 0;
        _ScoreTimer = new SplashKitSDK.Timer("ScoreTimer");
        _ScoreTimer.Start();

        _bullets = new List<Bullet>();


        this.gameWindow = gameWindow;
        this.Quit = false;
    }

    public void Draw()
    {
        gameWindow.DrawBitmap(_PlayerBitmap, X, Y);

        // Draw lives
        int x = 30;
        for (int i = 0; i < _Lives; i++)
        {
            _HeartBitmap = new Bitmap("heart_img" + i, "heart.png");
            gameWindow.DrawBitmap(_HeartBitmap, 10 + x * i, 20);
        }

        // Draw score
        gameWindow.DrawText($"Score: {_Score}", Color.Black, 10, 40);
    }

    public void HandleInput()
    {
        const int speed = 5;

        SplashKit.ProcessEvents();
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= speed;
            Draw();
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += speed;
            Draw();
        }
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += speed;
            Draw();
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= speed;
            Draw();
        }

        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            Quit = true;
        }
        if (gameWindow.CloseRequested)
        {
            Quit = true;
        }
        if (IsGameOver())
        {
            Quit = true;
        }
        if (SplashKit.MouseClicked(MouseButton.LeftButton))
        {
            double mouseX = SplashKit.MouseX();
            double mouseY = SplashKit.MouseY();

            // Calculate the angle to the mouse
            double angle = Math.Atan2(mouseY - Y, mouseX - X) * (180 / Math.PI);

            // Create a new bullet and add it to the list
            _bullets.Add(new Bullet(X, Y, angle));
        }

        StayOnWindow(gameWindow);
        UpdateScore();

    }
    public void UpdateBullets()
    {
        // Update all active bullets
        foreach (var bullet in _bullets)
        {
            bullet.Update();
        }

        // Remove inactive bullets
        _bullets.RemoveAll(bullet => !bullet.Active);
    }
    public void DrawBullets()
    {
        // Draw all active bullets
        foreach (var bullet in _bullets)
        {
            bullet.Draw();
        }
    }

    public void StayOnWindow(Window limit)
    {
        const int GAP = 10;
        if (X < GAP)
        {
            X = GAP;
        }
        if (X > (limit.Width - Width))
        {
            X = (limit.Width - Width);
        }

        if (Y > (limit.Height - Height))
        {
            Y = (limit.Width - Height);
        }
        if (Y < GAP)
        {
            Y = GAP;
        }
    }

    public bool CollidedWith(Robot other)
    {
        if (_PlayerBitmap.CircleCollision(X, Y, other.CollisionCircle))
        {
            LoseLife();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LoseLife()
    {
        _Lives--;
    }

    public bool IsGameOver()
    {
        return _Lives <= 0;
    }

    public void UpdateScore()
    {
        if (_ScoreTimer.Ticks / 1000 >= 1)
        {
            _Score += 1;
            _ScoreTimer.Reset();
            _ScoreTimer.Start();
        }
    }
}
