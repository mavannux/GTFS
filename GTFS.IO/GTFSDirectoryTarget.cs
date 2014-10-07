﻿// The MIT License (MIT)

// Copyright (c) 2014 Ben Abelshausen

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Collections.Generic;
using System.IO;

namespace GTFS.IO
{
    /// <summary>
    /// Represents a GTFS directory target.
    /// </summary>
    public class GTFSDirectoryTarget : IEnumerable<IGTFSTargetFile>
    {
        /// <summary>
        /// Holds the directory info.
        /// </summary>
        private DirectoryInfo _directory;

        /// <summary>
        /// Holds the target files.
        /// </summary>
        private List<IGTFSTargetFile> _targets;

        /// <summary>
        /// Creates a new GTFS directory target.
        /// </summary>
        /// <param name="directory"></param>
        public GTFSDirectoryTarget(DirectoryInfo directory)
        {
            _directory = directory;
            _targets = new List<IGTFSTargetFile>();
        }

        /// <summary>
        /// Builds the new target files.
        /// </summary>
        private void BuildTargets()
        {
            if (_targets.Count == 0)
            {
                // write files on-by-one.
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "agency"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "calendar_dates"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "calendar"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "fare_attributes"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "fare_rules"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "feed_info"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "frequencies"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "routes"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "shapes"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "stops"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "stop_times"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "tranfers"));
                _targets.Add(new GTFSTargetFileStream(_directory.FullName, "trips"));
            }
        }

        /// <summary>
        /// Returns the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IGTFSTargetFile> GetEnumerator()
        {
            this.BuildTargets();
            return _targets.GetEnumerator();
        }

        /// <summary>
        /// Returns the enumerator.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            this.BuildTargets();
            return _targets.GetEnumerator();
        }
    }
}
