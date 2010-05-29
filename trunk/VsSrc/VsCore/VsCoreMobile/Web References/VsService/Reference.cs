// ywyq	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ucsq	
// eriu	 By downloading, copying, installing or using the software you agree to this license.
// iycl	 If you do not agree to this license, do not download, install,
// vqmy	 copy or use the software.
// ferd	
// hxxc	                          License Agreement
// tgqs	         For OpenVSS - Open Source Video Surveillance System
// klux	
// hric	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ahjp	
// qbhh	Third party copyrights are property of their respective owners.
// tonz	
// tifu	Redistribution and use in source and binary forms, with or without modification,
// eujw	are permitted provided that the following conditions are met:
// epxy	
// aqjx	  * Redistribution's of source code must retain the above copyright notice,
// efed	    this list of conditions and the following disclaimer.
// hkyx	
// ucmf	  * Redistribution's in binary form must reproduce the above copyright notice,
// qqje	    this list of conditions and the following disclaimer in the documentation
// sqzc	    and/or other materials provided with the distribution.
// fzsm	
// ilxk	  * Neither the name of the copyright holders nor the names of its contributors 
// kkoa	    may not be used to endorse or promote products derived from this software 
// rkco	    without specific prior written permission.
// kjrj	
// kizb	This software is provided by the copyright holders and contributors "as is" and
// idgo	any express or implied warranties, including, but not limited to, the implied
// gsgk	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qhrf	In no event shall the Prince of Songkla University or contributors be liable 
// msvv	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mnnj	(including, but not limited to, procurement of substitute goods or services;
// olng	loss of use, data, or profits; or business interruption) however caused
// nvui	and on any theory of liability, whether in contract, strict liability,
// zqrx	or tort (including negligence or otherwise) arising in any way out of
// aqee	the use of this software, even if advised of the possibility of such damage.
// fies	
// eekk	Intelligent Systems Laboratory (iSys Lab)
// sxbs	Faculty of Engineering, Prince of Songkla University, THAILAND
// ovww	Project leader by Nikom SUVONVORN
// upnw	Project website at http://code.google.com/p/openvss/

namespace VsCoreMobile.VsService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="VsServiceSoap", Namespace="http://www.vsa-srv.com/")]
    public partial class VsService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public VsService() {
            this.Url = "http://172.30.136.110/vsservice/service.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/add", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void add(string name, string url) {
            this.Invoke("add", new object[] {
                        name,
                        url});
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginadd(string name, string url, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("add", new object[] {
                        name,
                        url}, callback, asyncState);
        }
        
        /// <remarks/>
        public void Endadd(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/showFiles", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL[] showFiles() {
            object[] results = this.Invoke("showFiles", new object[0]);
            return ((VsFileURL[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginshowFiles(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("showFiles", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public VsFileURL[] EndshowFiles(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsFileURL[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/showTables", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] showTables() {
            object[] results = this.Invoke("showTables", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginshowTables(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("showTables", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndshowTables(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/show", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL show() {
            object[] results = this.Invoke("show", new object[0]);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginshow(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("show", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public VsFileURL Endshow(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/HelloWorld", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndHelloWorld(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getCamAll", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsCamera[] getCamAll() {
            object[] results = this.Invoke("getCamAll", new object[0]);
            return ((VsCamera[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetCamAll(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getCamAll", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public VsCamera[] EndgetCamAll(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsCamera[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getCamHasMotion", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsCamera[] getCamHasMotion(System.DateTime timeBegin, System.DateTime timeEnd) {
            object[] results = this.Invoke("getCamHasMotion", new object[] {
                        timeBegin,
                        timeEnd});
            return ((VsCamera[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetCamHasMotion(System.DateTime timeBegin, System.DateTime timeEnd, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getCamHasMotion", new object[] {
                        timeBegin,
                        timeEnd}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsCamera[] EndgetCamHasMotion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsCamera[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/isCamHasMotion", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool isCamHasMotion(string cameraID, System.DateTime timeBegin, System.DateTime timeEnd) {
            object[] results = this.Invoke("isCamHasMotion", new object[] {
                        cameraID,
                        timeBegin,
                        timeEnd});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginisCamHasMotion(string cameraID, System.DateTime timeBegin, System.DateTime timeEnd, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("isCamHasMotion", new object[] {
                        cameraID,
                        timeBegin,
                        timeEnd}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndisCamHasMotion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMotionOfCamAsPeriod", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsMotion[] getMotionOfCamAsPeriod(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            object[] results = this.Invoke("getMotionOfCamAsPeriod", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID});
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetMotionOfCamAsPeriod(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getMotionOfCamAsPeriod", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsMotion[] EndgetMotionOfCamAsPeriod(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMotionOfAllAsPeriod", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsMotion[] getMotionOfAllAsPeriod(System.DateTime timeBegin, System.DateTime timeEnd) {
            object[] results = this.Invoke("getMotionOfAllAsPeriod", new object[] {
                        timeBegin,
                        timeEnd});
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetMotionOfAllAsPeriod(System.DateTime timeBegin, System.DateTime timeEnd, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getMotionOfAllAsPeriod", new object[] {
                        timeBegin,
                        timeEnd}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsMotion[] EndgetMotionOfAllAsPeriod(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMotionOfCamAsDay", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsMotion[] getMotionOfCamAsDay(string cameraID) {
            object[] results = this.Invoke("getMotionOfCamAsDay", new object[] {
                        cameraID});
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetMotionOfCamAsDay(string cameraID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getMotionOfCamAsDay", new object[] {
                        cameraID}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsMotion[] EndgetMotionOfCamAsDay(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMotionOfCamAsHour", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsMotion[] getMotionOfCamAsHour(string cameraID) {
            object[] results = this.Invoke("getMotionOfCamAsHour", new object[] {
                        cameraID});
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetMotionOfCamAsHour(string cameraID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getMotionOfCamAsHour", new object[] {
                        cameraID}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsMotion[] EndgetMotionOfCamAsHour(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMotionOfCamAsLast", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsMotion getMotionOfCamAsLast(string cameraID) {
            object[] results = this.Invoke("getMotionOfCamAsLast", new object[] {
                        cameraID});
            return ((VsMotion)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetMotionOfCamAsLast(string cameraID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getMotionOfCamAsLast", new object[] {
                        cameraID}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsMotion EndgetMotionOfCamAsLast(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsMotion)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getTimeOfLastMotion", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime getTimeOfLastMotion(string cameraId) {
            object[] results = this.Invoke("getTimeOfLastMotion", new object[] {
                        cameraId});
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetTimeOfLastMotion(string cameraId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getTimeOfLastMotion", new object[] {
                        cameraId}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.DateTime EndgetTimeOfLastMotion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getFileUrlOfMotion", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL getFileUrlOfMotion(string motionID, System.DateTime motionDateTime) {
            object[] results = this.Invoke("getFileUrlOfMotion", new object[] {
                        motionID,
                        motionDateTime});
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetFileUrlOfMotion(string motionID, System.DateTime motionDateTime, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getFileUrlOfMotion", new object[] {
                        motionID,
                        motionDateTime}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsFileURL EndgetFileUrlOfMotion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getFileUrlOfMotionResize", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL getFileUrlOfMotionResize(string motionID, System.DateTime motionDateTime, int w, int h) {
            object[] results = this.Invoke("getFileUrlOfMotionResize", new object[] {
                        motionID,
                        motionDateTime,
                        w,
                        h});
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetFileUrlOfMotionResize(string motionID, System.DateTime motionDateTime, int w, int h, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getFileUrlOfMotionResize", new object[] {
                        motionID,
                        motionDateTime,
                        w,
                        h}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsFileURL EndgetFileUrlOfMotionResize(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMjpegProxyUrlOfMotion", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL getMjpegProxyUrlOfMotion(string motionID, System.DateTime motionDateTime) {
            object[] results = this.Invoke("getMjpegProxyUrlOfMotion", new object[] {
                        motionID,
                        motionDateTime});
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetMjpegProxyUrlOfMotion(string motionID, System.DateTime motionDateTime, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getMjpegProxyUrlOfMotion", new object[] {
                        motionID,
                        motionDateTime}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsFileURL EndgetMjpegProxyUrlOfMotion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMjpegProxyUrlOfMotionParameter", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL getMjpegProxyUrlOfMotionParameter(string motionID, System.DateTime motionDateTime, int width, int heigth, int frameRate, int quanlity) {
            object[] results = this.Invoke("getMjpegProxyUrlOfMotionParameter", new object[] {
                        motionID,
                        motionDateTime,
                        width,
                        heigth,
                        frameRate,
                        quanlity});
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetMjpegProxyUrlOfMotionParameter(string motionID, System.DateTime motionDateTime, int width, int heigth, int frameRate, int quanlity, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getMjpegProxyUrlOfMotionParameter", new object[] {
                        motionID,
                        motionDateTime,
                        width,
                        heigth,
                        frameRate,
                        quanlity}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsFileURL EndgetMjpegProxyUrlOfMotionParameter(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getFileProxyUrlOfMotion", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL getFileProxyUrlOfMotion(string motionID, System.DateTime motionDateTime) {
            object[] results = this.Invoke("getFileProxyUrlOfMotion", new object[] {
                        motionID,
                        motionDateTime});
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetFileProxyUrlOfMotion(string motionID, System.DateTime motionDateTime, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getFileProxyUrlOfMotion", new object[] {
                        motionID,
                        motionDateTime}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsFileURL EndgetFileProxyUrlOfMotion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getFileProxyUrlOfMotionParameter", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL getFileProxyUrlOfMotionParameter(string motionID, System.DateTime motionDateTime, int width, int heigth, int frameRate, int quanlity) {
            object[] results = this.Invoke("getFileProxyUrlOfMotionParameter", new object[] {
                        motionID,
                        motionDateTime,
                        width,
                        heigth,
                        frameRate,
                        quanlity});
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetFileProxyUrlOfMotionParameter(string motionID, System.DateTime motionDateTime, int width, int heigth, int frameRate, int quanlity, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getFileProxyUrlOfMotionParameter", new object[] {
                        motionID,
                        motionDateTime,
                        width,
                        heigth,
                        frameRate,
                        quanlity}, callback, asyncState);
        }
        
        /// <remarks/>
        public VsFileURL EndgetFileProxyUrlOfMotionParameter(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getNumberOfMotion", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int getNumberOfMotion(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            object[] results = this.Invoke("getNumberOfMotion", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetNumberOfMotion(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getNumberOfMotion", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndgetNumberOfMotion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getNumberOfMotionInDay", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int[] getNumberOfMotionInDay(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            object[] results = this.Invoke("getNumberOfMotionInDay", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID});
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetNumberOfMotionInDay(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getNumberOfMotionInDay", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, callback, asyncState);
        }
        
        /// <remarks/>
        public int[] EndgetNumberOfMotionInDay(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getNumberOfMotionInMonth", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int[] getNumberOfMotionInMonth(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            object[] results = this.Invoke("getNumberOfMotionInMonth", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID});
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetNumberOfMotionInMonth(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getNumberOfMotionInMonth", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, callback, asyncState);
        }
        
        /// <remarks/>
        public int[] EndgetNumberOfMotionInMonth(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getNumberOfMotionInYear", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int[] getNumberOfMotionInYear(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            object[] results = this.Invoke("getNumberOfMotionInYear", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID});
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetNumberOfMotionInYear(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getNumberOfMotionInYear", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, callback, asyncState);
        }
        
        /// <remarks/>
        public int[] EndgetNumberOfMotionInYear(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getCamConfigToString", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getCamConfigToString() {
            object[] results = this.Invoke("getCamConfigToString", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetCamConfigToString(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getCamConfigToString", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndgetCamConfigToString(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getCamConfigToByte", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] getCamConfigToByte() {
            object[] results = this.Invoke("getCamConfigToByte", new object[0]);
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetCamConfigToByte(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getCamConfigToByte", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public byte[] EndgetCamConfigToByte(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMyHost", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getMyHost() {
            object[] results = this.Invoke("getMyHost", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetMyHost(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getMyHost", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndgetMyHost(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getConfig", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getConfig() {
            object[] results = this.Invoke("getConfig", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetConfig(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getConfig", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndgetConfig(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        internal void getCamAllAsync()
        {
            throw new NotImplementedException();
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.vsa-srv.com/")]
    public partial class VsFileURL {
        
        private string filesNameField;
        
        private string filesIDField;
        
        private string filesURLField;
        
        /// <remarks/>
        public string FilesName {
            get {
                return this.filesNameField;
            }
            set {
                this.filesNameField = value;
            }
        }
        
        /// <remarks/>
        public string FilesID {
            get {
                return this.filesIDField;
            }
            set {
                this.filesIDField = value;
            }
        }
        
        /// <remarks/>
        public string FilesURL {
            get {
                return this.filesURLField;
            }
            set {
                this.filesURLField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.vsa-srv.com/")]
    public partial class VsMotion {
        
        private int motionIDField;
        
        private string cameraIDField;
        
        private string processorField;
        
        private string r_algo_nameField;
        
        private System.DateTime timeBeginField;
        
        private System.DateTime timeEndField;
        
        private string r_detailField;
        
        /// <remarks/>
        public int MotionID {
            get {
                return this.motionIDField;
            }
            set {
                this.motionIDField = value;
            }
        }
        
        /// <remarks/>
        public string cameraID {
            get {
                return this.cameraIDField;
            }
            set {
                this.cameraIDField = value;
            }
        }
        
        /// <remarks/>
        public string processor {
            get {
                return this.processorField;
            }
            set {
                this.processorField = value;
            }
        }
        
        /// <remarks/>
        public string r_algo_name {
            get {
                return this.r_algo_nameField;
            }
            set {
                this.r_algo_nameField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime timeBegin {
            get {
                return this.timeBeginField;
            }
            set {
                this.timeBeginField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime timeEnd {
            get {
                return this.timeEndField;
            }
            set {
                this.timeEndField = value;
            }
        }
        
        /// <remarks/>
        public string r_detail {
            get {
                return this.r_detailField;
            }
            set {
                this.r_detailField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.vsa-srv.com/")]
    public partial class VsCamera {
        
        private string cameraIDField;
        
        private string locationField;
        
        /// <remarks/>
        public string cameraID {
            get {
                return this.cameraIDField;
            }
            set {
                this.cameraIDField = value;
            }
        }
        
        /// <remarks/>
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
    }
}
