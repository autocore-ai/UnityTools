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
    class CsvStopLine
    {
        internal const string fileName = "stopline.csv";
        internal const string header = "ID,LID,TLID,SignID,LinkID";
        public CsvLine Line { get; set; }
        public CsvSignalLight SignalLight { get; set; }
        public CsvLane Lane { get; set; }
        public int ID { get; set; }
        public int? LID => Line?.LID;
        public int? TLID => SignalLight?.ID;
        public int? LinkID => Lane?.LnID;
        public string CsvString => $"{ID},{LID ?? 0},{TLID ?? 0},0,{LinkID ?? 0}";
        public static implicit operator Roslin.Msg.vector_map_msgs.StopLine (CsvStopLine csvStopLine)
        {
            return new Roslin.Msg.vector_map_msgs.StopLine
            {
                id = csvStopLine.ID,
                lid = csvStopLine.LID ?? 0,
                tlid = csvStopLine.TLID ?? 0,
                signid = 0,
                linkid = csvStopLine.LinkID ?? 0
            };
        }
    }
}