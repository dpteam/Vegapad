using System;
using System.ComponentModel;

namespace FileDialogExtenders
{
	public enum Places
	{
		[Description("Desktop")]
		Desktop,
		[Description("Internet Explorer ")]
		InternetExplorer,
		[Description("Program Files")]
		Programs,
		[Description("Control Panel")]
		ControlPanel,
		[Description("Printers")]
		Printers,
		[Description("My Documents")]
		MyDocuments,
		[Description("Favorites")]
		Favorites,
		[Description("Startup folder")]
		StartupFolder,
		[Description("Recent Files")]
		RecentFiles,
		[Description("Send To")]
		SendTo,
		[Description("Recycle Bin")]
		RecycleBin,
		[Description("Start menu")]
		StartMenu,
		[Description("Logical My Documents")]
		Logical_MyDocuments,
		[Description("My Music")]
		MyMusic,
		[Description("My Videos")]
		MyVideos,
		[Description("<user name>\\Desktop")]
		UserName_Desktop = 16,
		[Description("My Computer")]
		MyComputer,
		[Description("My Network Places")]
		MyNetworkPlaces,
		[Description("<user name>\nethood")]
		User_Name_Nethood,
		[Description("Fonts")]
		Fonts,
		[Description("All Users\\Start Menu")]
		All_Users_StartMenu = 22,
		[Description("All Users\\Start Menu\\Programs ")]
		All_Users_StartMenu_Programs,
		[Description("All Users\\Startup")]
		All_Users_Startup,
		[Description("All Users\\Desktop")]
		All_Users_Desktop,
		[Description("<user name>\\Application Data ")]
		User_name_ApplicationData,
		[Description("<user name>\\PrintHood ")]
		User_Name_PrintHood,
		[Description("<user name>\\Local Settings\\Applicaiton Data (nonroaming)")]
		Local_ApplicaitonData,
		[Description("Nonlocalized common startup ")]
		NonlocalizedCommonStartup = 30,
		[Description("")]
		CommonFavorites,
		[Description("Internet Cache ")]
		InternetCache,
		[Description("Cookies ")]
		Cookies,
		[Description("History")]
		History,
		[Description("All Users\\Application Data ")]
		All_Users_ApplicationData,
		[Description("Windows Directory")]
		WindowsDirectory,
		[Description("System Directory")]
		SystemDirectory,
		[Description("Program Files ")]
		ProgramFiles,
		[Description("My Pictures ")]
		MyPictures,
		[Description("USERPROFILE")]
		USERPROFILE,
		[Description("system directory on RISC")]
		SYSTEN_RISC,
		[Description("Program Files on RISC ")]
		Program_Files_RISC,
		[Description("Program Files\\Common")]
		Common,
		[Description("Program Files\\Common on RISC")]
		Common_RISC,
		[Description("All Users\\Templates ")]
		Templates,
		[Description("All Users\\Documents")]
		All_Users_Documents,
		[Description("All Users\\Start Menu\\Programs\\Administrative Tools")]
		AdministrativeTools,
		[Description("<user name>\\Start Menu\\Programs\\Administrative Tools")]
		USER_AdministrativeTools,
		[Description("Network and Dial-up Connections")]
		Network_DialUp_Connections,
		[Description("All Users\\My Music")]
		All_Users_MyMusic = 53,
		[Description("All Users\\My Pictures")]
		All_Users_MyPictures,
		[Description("All Users\\My Video")]
		All_Users_MyVideo,
		[Description("Resource Directory")]
		Resource,
		[Description("Localized Resource Directory ")]
		Localized_Resource,
		[Description("OEM specific apps")]
		OEM_Specific,
		[Description("USERPROFILE\\Local Settings\\Application Data\\Microsoft\\CD Burning")]
		CDBurning
	}
}
