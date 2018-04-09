//-----------------------------------------------------------------------------
//   Copyright @2013 Rockwell Automation, Inc. All Rights Reserved.
//   This program is the proprietary property of Rockwell Automation Inc.
//   and it shall not be reproduced, distributed or used in any way without the 
//   approval of an authorized company official.  This program is an unpublished
//   work subject to Trade Secret and Copyright protection.  All rights to this
//   program are reserved to Rockwell Automation Inc
// <Revision History>
// 12-Aug-2013      Paddy Lu        Added for generating the module token
// </Revision History>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using RA.CCW.Logger;
using RA.CCW.MSP.ModuleProfileLoader;
using RA.CCW.MSP.ModuleProfileLoader.Base;
using RA.CCW.MSP.ModuleProfileLoader.Base.ModuleInfoInterface;

namespace RA.CCW.TokenGenerator
{
    public class ProfileTokenGenerator : IProfileTokenGenerator
    {
        #region private variables

        private readonly ICCWLogger logger;

        #endregion

        #region C'or

        public ProfileTokenGenerator(ICCWLogger logger = null)
        {
            this.logger = logger;
        }

        #endregion

        #region public function

        public string GenerateProfileToken(string moduleProfilePath, IList<string> resourcesFilePathList,
            IList<string> featurePageFilePathList, IList<string> dataSourceilePathList)
        {
            XElement xmlDoc = LoadXMLFile(moduleProfilePath);

            string moduleProfileToken = GetModuleProfileToken(xmlDoc);

            string resourceToken = GetResourceFileToken(resourcesFilePathList);

            string featurePageToken = GetFeaturePageToken(featurePageFilePathList);

            string dataSourceToken = GetDataSourceToken(dataSourceilePathList);

            string tokenString = GetTokenString(moduleProfileToken, resourceToken, featurePageToken, dataSourceToken);

            return GenerateToken(tokenString);
        }

        public string GenerateProfileToken(string moduleProfilePath, IList<string> resourcesFiles)
        {
       
            string moduleFolderPath = ModuleProfileUtilities.GetModuleParentPath(moduleProfilePath);

            var pageLayoutDefList = GetPageLayoutDefList(moduleProfilePath);

            IList<string> featurePageList = GetFeaturePagePathList(pageLayoutDefList, moduleFolderPath);

            IList<string> dataSourceList = GetDataSourcePathList(pageLayoutDefList, moduleFolderPath);

            return GenerateProfileToken(moduleProfilePath, resourcesFiles, featurePageList, dataSourceList);
        }

        private IList<IPageLayoutDef> GetPageLayoutDefList(string moduleProfilePath)
        {
            XElement xmlDoc = LoadXMLFile(moduleProfilePath);
            IList<IPageLayoutDef> pageLayoutDefList =
                ModuleProfileUtilities.GetPageLayoutDefs(GetModules(xmlDoc));
            return pageLayoutDefList;
        }

        private string GetTokenString(string moduleProfileToken, string resourceToken, string featurePageToken,
            string dataSourceToken)
        {
            var builder = new StringBuilder();
            builder.Append(moduleProfileToken).Append(resourceToken).Append(featurePageToken).Append(dataSourceToken);

            return builder.ToString();
        }

        private string GetDataSourceToken(IList<string> dataSourceilePathList)
        {
            string dataSourceTokenString = GetDataSourceStringForToken(dataSourceilePathList);
            string dataSourceToken = GenerateToken(dataSourceTokenString);

            return dataSourceToken;
        }

        private string GetFeaturePageToken(IList<string> featurePageFilePathList)
            {
            string featurePageTokenString = GetFeaturePageStringForToken(featurePageFilePathList);

            string featurePageToken = GenerateToken(featurePageTokenString);

            return featurePageToken;
            }

        private string GetResourceFileToken(IList<string> resourcePathList)
        {
            string resourceTokenString = GetResourceListStringForToken(resourcePathList);

            string resourceToken = GenerateToken(resourceTokenString);

            return resourceToken;
        }

        private string GetModuleProfileToken(XElement xmlDoc)
        {
            string moduleProfileTokenString = GetModuleProfileStringForToken(xmlDoc);

            string moduleProfileToken = GenerateToken(moduleProfileTokenString);

            return moduleProfileToken;
        }

        #endregion

        #region private function

        /// <summary>
        /// Load the XML file from the specific file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private XElement LoadXMLFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                LogInformation("Generate module Identity: Input file path is empty");
                return null;
            }

            if (!File.Exists(filePath))
            {
                LogInformation("Generate module Identity: Input file doesn't exist.");
                return null;
            }

            try
            {
                return XElement.Load(filePath);
            }
            catch (Exception)
            {
                LogInformation("Generate module Identity: Load module profile failed.");
                return null;
            }
        }

        /// <summary>
        /// The wrapper class for logger
        /// </summary>
        /// <param name="logInfo"></param>
        private void LogInformation(string logInfo)
        {
            if (string.IsNullOrWhiteSpace(logInfo) || logger == null)
                return;

            logger.WarnFormat(logInfo);
        }

        /// <summary>
        /// Get the content of the specific file
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        private string GetFileContent(XElement xmlDoc)
        {
            return xmlDoc == null ? string.Empty : string.Join("", xmlDoc.Nodes().Select(e => e.ToString()).ToArray());
        }


        /// <summary>
        ///     Generate the module profile token from the XML file content
        /// </summary>
        /// <param name="profileFileContent"></param>
        /// <returns></returns>
        private string GetModuleProfileStringForToken(XElement profileFileContent)
        {
            string fileContent = GetFileContent(profileFileContent);

            return fileContent;
        }

        private string GetResourceListStringForToken(IList<string> resourcePathList)
        {
            return GetStringForToken(resourcePathList);
        }


        private string GetFeaturePageStringForToken(IList<string> featurePagePathList)
        {
            return GetStringForToken(featurePagePathList);
        }


        private string GetDataSourceStringForToken(IList<string> dataSourcePathList)
        {
            return GetStringForToken(dataSourcePathList);
        }


        private string GetStringForToken(IList<string> fileList)
        {
            var builder = new StringBuilder();
            IOrderedEnumerable<string> sortedFileList = from file in fileList
                orderby file
                select file;

            foreach (string filePath in sortedFileList)
            {
                var fileReader = new StreamReader(filePath);

                string fileToken = GenerateToken(fileReader.ReadToEnd());

                builder.Append(fileToken);

                fileReader.Close();
            }
            return builder.ToString();
        }

        private IList<IModule> GetModules(XElement rootElement)
        {
            return ModuleProfileUtilities.LoadModuleProfile(rootElement, GetModuleProfileVersion(rootElement));
        }

        private string GetModuleProfileVersion(XElement moduleProfileRoot)
        {
            return ModuleProfileUtilities.GetProfileFileVersion(logger, moduleProfileRoot);
        }


        private static string GenerateToken(string fileContent)
        {
            return string.IsNullOrWhiteSpace(fileContent) ? string.Empty : TokenGenerator.GenerateToken(fileContent);
        }

        private IList<string> GetFeaturePagePathList(IList<IPageLayoutDef> pageLayoutDefList, string packagePath)
        {
            return ModuleProfileUtilities.GetXamlPagePathList(pageLayoutDefList, packagePath);
        }


        private IList<string> GetDataSourcePathList(IList<IPageLayoutDef> pageLayoutDefList, string packagePath)
        {
            return ModuleProfileUtilities.GetDataSourcePathList(pageLayoutDefList, packagePath);
        }

        #endregion
    }
}