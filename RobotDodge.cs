using System;
using SplashKitSDK;
public class RobotDodgeGame
{
    private Player _Player;

    private Window _GameWindow;

    private List<Robot> _Robots = new List<Robot>();

    public bool Quit
    {
        get
        {
            return _Player.Quit;
        }
    }

    public RobotDodgeGame(Window gameWindow)
    {
        this._GameWindow = gameWindow;
        this._Player = new Player(gameWindow);


        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0)
            {
                _Robots.Add(new Roundy(gameWindow, _Player));
            }
            else
            {
                _Robots.Add(new Boxy(gameWindow, _Player));
            }


        }

    }
    public void Draw()
    {
        _GameWindow.Clear(Color.WhiteSmoke);

        foreach (Robot r in _Robots)
        {
            r.Draw();
        }
        this._Player.Draw();
        _Player.DrawBullets();
        _GameWindow.Refresh(60);

    }

    public void HandleInput()
    {
        this._Player.HandleInput();
        this._Player.StayOnWindow(_GameWindow);

    }

    public void Update()
    {
        UpdateRobots();
        _Player.UpdateBullets(); // Update the player's bullets
        CheckBulletCollisions();
    }
  bool flag = false;
    private void CheckCollisions()
    {
        List<Robot> list = new List<Robot>();
        foreach (Robot r in _Robots)
        {
            if (_Player.CollidedWith(r) || r.IsOffScreen(_GameWindow))
            {
                list.Add(r);
            }
        }

      
        foreach (Robot l in list)
        {
            _Robots.Remove(l);
            if (flag == true)
            {
                _Robots.Add(new Roundy(this._GameWindow, _Player));
                flag = false;
            }
            else
            {
                _Robots.Add(new Boxy(this._GameWindow, _Player));
                flag = true;
            }

        }
    }
    private void UpdateRobots()
    {
        foreach (Robot r in _Robots)
        {
            r.Update();
        }
        CheckCollisions();
    }

    private void CheckBulletCollisions()
    {
        List<Robot> destroyedRobots = new List<Robot>();
        List<Bullet> bulletsToRemove = new List<Bullet>();
        foreach (Robot r in _Robots)
        {
            foreach (Bullet bullet in _Player._bullets)
            {
                if (bullet.HasCollidedWith(r))
                {
                    destroyedRobots.Add(r);
                    bulletsToRemove.Add(bullet);
                }
            }
        }
        _Robots.RemoveAll(robot => destroyedRobots.Contains(robot));
        _Player._bullets.RemoveAll(bullet => bulletsToRemove.Contains(bullet));
    }

}