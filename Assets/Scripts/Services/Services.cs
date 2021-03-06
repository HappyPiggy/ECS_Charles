﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Services
{
    public readonly IInputService inputService;
    public readonly ConfigService configService;
    public readonly IViewService unityViewService;
    public readonly IEntityFactoryService entityFactoryService;
    public readonly IAudioService audioService;

    public Services(IInputService inputService, ConfigService configService, IViewService unityViewService, IEntityFactoryService entityFactoryService,IAudioService audioService)
    {
        this.inputService = inputService;
        this.configService = configService;
        this.unityViewService = unityViewService;
        this.entityFactoryService = entityFactoryService;
        this.audioService = audioService;
    }
}

