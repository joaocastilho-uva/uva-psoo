﻿using System.ComponentModel;

namespace App.Enums
{
    public enum Categoria
    {
        [Description("Todos os produtos")]
        Todos = 1,

        [Description("Esculturas")]
        Esculturas = 2,

        [Description("Home decor")]
        HomeDecor = 3,

        [Description("Iluminação")]
        Iluminacao = 4,

        [Description("Móveis")]
        Moveis = 5,

        [Description("Wall decor")]
        WallDecor = 6
    }
}
