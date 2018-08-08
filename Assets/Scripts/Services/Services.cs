using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Services
{
    public readonly IInputService input;
    public readonly ConfigService config;
    public readonly IViewService unityViewService;

    public Services(IInputService input,ConfigService config,IViewService viewService)
    {
        this.input = input;
        this.config = config;
        this.unityViewService = viewService;
    }
}

