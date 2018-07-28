using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Services
{
    public readonly IInputService Input;
    public readonly IViewService View;
    public readonly IPoolService Pool;
    public readonly IConfigurationService GameConfig;

    public Services(IInputService input, IViewService view, IPoolService pool)
    {
        Input = input;
        View = view;
        Pool = pool;
    }

    public Services(IInputService input, IViewService view, IPoolService pool, IConfigurationService gameConfig)
    {
        Input = input;
        View = view;
        Pool = pool;
        GameConfig = gameConfig;
    }
}