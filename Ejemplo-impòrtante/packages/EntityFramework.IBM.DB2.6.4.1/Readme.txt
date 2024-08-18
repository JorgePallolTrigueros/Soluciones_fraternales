IBM Data Server EF 6 Provider for Entity Framework 6 applications accessing IBM Data Servers
============================================================================================

As part of this release, IBM Data Server EF 6 Provider will be shipped via a NuGet package, EntityFramework.IBM.DB2 (6.4.0) available on nuget.org.
This package, EntityFramework.IBM.DB2 - is built on MS EF 6.4.0.

Prerequisites:
--------------
1. Download Entity Framework 6 Tools for Visual Studio versions >= 2012:
   http://www.microsoft.com/en-us/download/details.aspx?id=40762

2. Download DB2 Version 10.5 Fix Pack 5 clients/drivers for Windows or later, apllications targeting .NET Framework:
   http://www-01.ibm.com/support/docview.wss?uid=swg24038828

   - For EF 6.4 apllications targeting .NET Standard 2.1, this package has dependency on 
     IBM.Data.DB2.Core (3.1.0.400-alpha)/IBM.Data.DB2.Core-lnx (3.1.0.400-alpha)/IBM.Data.DB2.Core-osx (3.1.0.400-alpha) Nuget package based upon 
     underlying Operating System.

Limitations:
------------
1. This release adds toleration support for Entity Framework 6.4.0 multi-targeting i.e. .NET Framework 4.6.1 and .NET Standard 2.1 on Windows Linux and OS X.

2. Entity Framework 6.4.0 apps targeting .NET Standard 2.1 would require Code based configuration of EF6 Provider e.g.:

    public class DB2EF6CodeBasedConfig : DbConfiguration
    {
        public DB2EF6CodeBasedConfig()
        {
            //SetDefaultConnectionFactory(new DB2ConnectionFactory());
            SetProviderFactory("IBM.Data.DB2.Core", DB2Factory.Instance);
            SetProviderServices("IBM.Data.DB2.Core", DB2ProviderServices.Instance);
        }
    }

3. In App/Web.config we need to update "provider" keyword to "IBM.Data.DB2.Core" in the corresponding connectionString.

4. A known issue with MS EF Tooling, if an application targets the x64 platform using our 'IBM Data Server EF 6 Provider' during EDM creation,
   It will see "Your project references the latest version of Entity Framework; however, an Entity Framework database provider compatible with
   this version could not be found for your data connection. If you have already installed a compatible provider, ensure you have rebuilt your project
   before performing this action. Otherwise, exit this wizard, install a compatible provider, and rebuild your project before performing this action" exception.
   
   The following link details about this issue:
   https://entityframework.codeplex.com/workitem/2506
   
   Possible Workarounds:
   i) Move the EF model into its own project that compiles as Any CPU, then add that project as a dependency of the x64 (64-bit) StartUp project.
  ii) Target the application to Any CPU platform.
 
Assistance:
---------
For questions about using this release of IBM Data Server EF 6 Provider, please post a question on:
https://community.ibm.com/community/user/hybriddatamanagement/communities/community-home?communitykey=f2e5dc34-896d-4e8e-9678-724907c4b9f5&tab=groupdetails

An ongoing discusssion that highlights IBM Data Server EF 6 Provider targeting .NET Standard 2.1:
https://community.ibm.com/community/user/hybriddatamanagement/communities/community-home/digestviewer/viewthread?MessageKey=c4dd3533-41c3-4d3d-a531-67f3c2f2e9bb&CommunityKey=f2e5dc34-896d-4e8e-9678-724907c4b9f5&tab=digestviewer#bmc4dd3533-41c3-4d3d-a531-67f3c2f2e9bb

