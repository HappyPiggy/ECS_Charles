using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ItemView :BaseView,IGameDestroyedListener
{

    private void Start()
    {
        gameEntity.AddGameDestroyedListener(this);
    }

    public void OnDestroyed(GameEntity entity)
    {
        OnDestroyedView();
    }


}