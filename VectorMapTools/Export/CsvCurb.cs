﻿#region License
/******************************************************************************
* Copyright 2019 The AutoCore Authors. All Rights Reserved.
* 
* Licensed under the GNU Lesser General Public License, Version 3.0 (the "License"); 
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
* 
* https://www.gnu.org/licenses/lgpl-3.0.html
* 
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*****************************************************************************/
#endregion

namespace Packages.MapToolbox.VectorMapTools.Export
{
    class CsvCurb
    {
        internal const string fileName = "curb.csv";
        internal const string header = "ID,LID,Height,Width,Dir,LinkID";
        internal CsvLine Line { get; set; }
        internal int ID { get; set; }
        internal int? LID => Line?.LID;
        internal float Height { get; set; } = 0.15f;
        internal float Width { get; set; } = 0.15f;
        internal float Dir { get; set; } = 1;
        internal string CsvString => $"{ID},{LID ?? 0},{Height},{Width},{Dir},0";
        public static implicit operator Roslin.Msg.vector_map_msgs.Curb( CsvCurb csvCurb)
        {
            return new Roslin.Msg.vector_map_msgs.Curb
            {
                id = csvCurb.ID,
                lid = csvCurb.LID ?? 0,
                height = csvCurb.Height,
                width = csvCurb.Width,
                dir = (int)csvCurb.Dir,
                linkid = 0
            };
        }
    }
}