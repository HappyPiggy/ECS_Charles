using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Services
{
    public readonly IInputService input;
    public readonly ConfigService config;
    public readonly IViewService unityViewService;
    public readonly IEntityFactoryService entityFactoryService;

    public Services(IInputService input,ConfigService config,IViewService unityViewService, IEntityFactoryService entityFactoryService)
    {
        this.input = input;
        this.config = config;
        this.unityViewService = unityViewService;
        this.entityFactoryService = entityFactoryService;
    }
}

