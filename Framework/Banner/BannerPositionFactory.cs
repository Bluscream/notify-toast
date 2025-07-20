/********************************************************************
 * Copyright (C) 2015-2017 Antoine Aflalo
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 ********************************************************************/

using NotifyToast.Banner.Position;
using NotifyToast.Framework.Factory;

namespace NotifyToast.Banner
{
    public class BannerPositionFactory : NotifyToast.Framework.Factory.AbstractFactory<BannerPositionEnum, NotifyToast.Banner.Position.IPosition>
    {
        private static readonly NotifyToast.Framework.Factory.IEnumImplList<BannerPositionEnum, NotifyToast.Banner.Position.IPosition> Positions = new NotifyToast.Framework.Factory.EnumImplList<BannerPositionEnum, NotifyToast.Banner.Position.IPosition>
            {
                new PositionTopLeft(),
                new PositionTopCenter(),
                new PositionTopRight(),
                new PositionBottomLeft(),
                new PositionBottomCenter(),
                new PositionBottomRight(),
                new PositionCenter()
            };

        public BannerPositionFactory() : base(Positions)
        {
        }
    }
}
