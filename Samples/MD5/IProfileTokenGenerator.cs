//-----------------------------------------------------------------------------
//   Copyright @2013 Rockwell Automation, Inc. All Rights Reserved.
//   This program is the proprietary property of Rockwell Automation Inc.
//   and it shall not be reproduced, distributed or used in any way without the 
//   approval of an authorized company official.  This program is an unpublished
//   work subject to Trade Secret and Copyright protection.  All rights to this
//   program are reserved to Rockwell Automation Inc
// <Revision History>
// 12-Aug-2013      Paddy Lu        Added for generating the module token
// 24-Sep-2013      Anthony Zhu     Change functions the interface.
// </Revision History>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RA.CCW.TokenGenerator
{
    public interface IProfileTokenGenerator
    {
        /// <summary>
        /// Get the module profile token
        /// </summary>
        /// <param name="moduleProfilePath">Module profile path</param>
        /// <param name="resourceFilePathList">List of resource file path</param>
        /// <returns></returns>
        string GenerateProfileToken(string moduleProfilePath, IList<string> resourceFilePathList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleProfilePath">Module profile path</param>
        /// <param name="resourceFilePathList">List of resource file path</param>
        /// <param name="featurePagePathList">List of feature path path</param>
        /// <param name="dataSourcePathList">List of data source path</param>
        /// <returns></returns>
        string GenerateProfileToken(string moduleProfilePath, IList<string> resourceFilePathList, IList<string> featurePagePathList, IList<string> dataSourcePathList);
    }
}
