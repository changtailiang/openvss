### What's new on Release 1.0!!! ###
More features...
  * Very simple to integrate your image analysis techniques into OpenVSS platform using a source code generator, called “VsAnalyser SDK”. OpenCV 2.0 is now completely integrated with your plug-in!!!.
  * More stable platform.
  * Web-based and Mobile-based client will available zoon.
### Introduction ###
**OpenVSS** - Open Platform Video Surveillance System - is a system level video surveillance software based on a [Video Analysis Framework (VAF)](http://fivedots.coe.psu.ac.th/~kom/?p=613) technology for video analyzing, recording and indexing, with searching and playback services. It is designed as plug-in style for supporting multi-cameras platform, multi-analyzers module (OpenCV integrated), and multi-cores architecture.

**OpenVSS** software consists of three main packages:
  * **OpenVSS Server**: an online video processing system for analyzing, recording and indexing.
    * VsMonitor - video analyzer management.
    * VsAdmin - remote connection tool for activating the analyzer, recorder, and alerter.
    * VsSystem - system configuration tool.
    * VsService - service configuration tool.
  * **OpenVSS Client**: client applications.
    * VsLive -video live views.
    * VsPlayback - video searching and playback.
    * VsWeb - live view and playback on web ...coming zoon...
    * VsMobile - live view and playback on mobile ...coming zoon...
  * **OpenVSS SDK**: additional plug-ins.
    * VsAnalyzerSDK - analyzer plug-in, source code generator integrated with OpenCV 2.0.
    * VsProviderSDK - provider plug-in ...coming zoon...
    * VsAlerterSDK - alerter plug-in ...coming zoon...
### Requirements ###
  * To run server as online video processing with analysing, recording and indexing,  the following software are needed : [MySQL database server](http://www.mysql.com), [IIS web server](http://www.iis.net), and [Windows Media Encoder 9 Series](http://www.microsoft.com/downlOAds/details.aspx?familyid=5691BA02-E496-465A-BBA9-B2F1182CDF24&displaylang=en).
  * For the **research** that requires only for algorithm evaluation: install only "OpenVSS Server" and "VsAnalyzer SDK" packages, uses VsMonitor for testing your algorithms. No any additional software specified above needed.
  * .NET Framework 3.5 is neccesary.
  * OpenVSS is completely tested only on Windows XP SP3, and partially done for Windows Vista and Windows 7.
### Tutorial ###
  * "Installation, Setup, and Programming on OpenVSS", 01-June-2010, at [SIIT](http://www.siit.tu.ac.th), supported by SIIT and NECTEC.
  * "การติดตั้ง การใช้งาน และการพัฒนาโปรแกรมการวิเคราะห์ภาพวีดีโอบนระบบ OpenVSS – Open Platform Video Surveillance System", 23 มิ.ย. 2553, ที่ [ห้อง R101 ตึกหุ่นยนต์ ภาควิชาวิศวกรรมคอมพิวเตอร์ มอ.หาดใหญ่ จ.สงขลา](http://www.coe.psu.ac.th), วันอังคารที่ 23 มิถุนายน พ.ศ. 2553 เวลา 10:00 – 12:00 น. สนับสนุนโดย ภาควิชาวิศวกรรมคอมพิวเตอร์ มอ.
### Notes ###
  * OpenVSS has been designed and developed at [Department of Computer Engineering](http://www.coe.psu.ac.th), [Prince of Songkla University](http://www.psu.ac.th), THAILAND. The project leader by [Nikom SUVONVORN](http://fivedots.coe.psu.ac.th/~kom) - iSys Research Laboratory member.
  * OpenVSS is partially funded by:
    * 2007 - [Faculty of Engineering](http://www.eng.psu.ac.th), Prince of Songkla University, ~1.5k dollars.
    * 2007 - [Research and Development Office](http://rdo.psu.ac.th), Prince of Songkla University, ~1.5k dollars.
    * 2009 - [NECTEC - National Electronics and Computer Technology Center](http://www.nectec.or.th) Thailand, ~14k dollars.
    * **IF THIS PROJECT HELPS YOU, SUPPORT US...** [![](https://www.paypal.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=95UQ3ANRV5V44)

---

### Software demonstration ###
### VsMonitor : basic image techniques ###
<a href='http://www.youtube.com/watch?feature=player_embedded&v=HJrTZprcGYA' target='_blank'><img src='http://img.youtube.com/vi/HJrTZprcGYA/0.jpg' width='425' height=344 /></a>

### VsMonitor : face detection with Haar-like ###
<a href='http://www.youtube.com/watch?feature=player_embedded&v=htK_ZikaSng' target='_blank'><img src='http://img.youtube.com/vi/htK_ZikaSng/0.jpg' width='425' height=344 /></a>

### VsLive ###
<a href='http://www.youtube.com/watch?feature=player_embedded&v=_EOJevJXAoE' target='_blank'><img src='http://img.youtube.com/vi/_EOJevJXAoE/0.jpg' width='425' height=344 /></a>

### VsPlayback ###
<a href='http://www.youtube.com/watch?feature=player_embedded&v=DmDm5EMYWzA' target='_blank'><img src='http://img.youtube.com/vi/DmDm5EMYWzA/0.jpg' width='425' height=344 /></a>

### VsServer ###
<a href='http://www.youtube.com/watch?feature=player_embedded&v=zNWVISsZjsA' target='_blank'><img src='http://img.youtube.com/vi/zNWVISsZjsA/0.jpg' width='425' height=344 /></a>
### VsClient ###
<a href='http://www.youtube.com/watch?feature=player_embedded&v=IkPpdURg7xE' target='_blank'><img src='http://img.youtube.com/vi/IkPpdURg7xE/0.jpg' width='425' height=344 /></a>

### VsConfig ###
<a href='http://www.youtube.com/watch?feature=player_embedded&v=ZN6B9CKR4C0' target='_blank'><img src='http://img.youtube.com/vi/ZN6B9CKR4C0/0.jpg' width='425' height=344 /></a>