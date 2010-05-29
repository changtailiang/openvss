// kcsk	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ffzq	
// lqdc	 By downloading, copying, installing or using the software you agree to this license.
// aplc	 If you do not agree to this license, do not download, install,
// mscl	 copy or use the software.
// dvqv	
// tkvv	                          License Agreement
// lcps	         For OpenVSS - Open Source Video Surveillance System
// atop	
// bnpd	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// ajqe	
// fznd	Third party copyrights are property of their respective owners.
// cyia	
// hgjo	Redistribution and use in source and binary forms, with or without modification,
// lwqv	are permitted provided that the following conditions are met:
// jeej	
// albh	  * Redistribution's of source code must retain the above copyright notice,
// awby	    this list of conditions and the following disclaimer.
// dylu	
// emqt	  * Redistribution's in binary form must reproduce the above copyright notice,
// wssn	    this list of conditions and the following disclaimer in the documentation
// tpku	    and/or other materials provided with the distribution.
// kade	
// wtuw	  * Neither the name of the copyright holders nor the names of its contributors 
// ehdu	    may not be used to endorse or promote products derived from this software 
// ygcf	    without specific prior written permission.
// xjwj	
// vpjz	This software is provided by the copyright holders and contributors "as is" and
// gxyq	any express or implied warranties, including, but not limited to, the implied
// lrql	warranties of merchantability and fitness for a particular purpose are disclaimed.
// ahxa	In no event shall the Prince of Songkla University or contributors be liable 
// twcj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// eppx	(including, but not limited to, procurement of substitute goods or services;
// iwvq	loss of use, data, or profits; or business interruption) however caused
// pmqj	and on any theory of liability, whether in contract, strict liability,
// sbzu	or tort (including negligence or otherwise) arising in any way out of
// qdxz	the use of this software, even if advised of the possibility of such damage.
// vdkn	
// qstq	Intelligent Systems Laboratory (iSys Lab)
// jcma	Faculty of Engineering, Prince of Songkla University, THAILAND
// gnef	Project leader by Nikom SUVONVORN
// zlqk	Project website at http://code.google.com/p/openvss/

namespace Vs.Playback.VsService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="VsServiceSoap", Namespace="http://www.vsa-srv.com/")]
    public partial class VsService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback addOperationCompleted;
        
        private System.Threading.SendOrPostCallback showFilesOperationCompleted;
        
        private System.Threading.SendOrPostCallback showTablesOperationCompleted;
        
        private System.Threading.SendOrPostCallback showOperationCompleted;
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback getCamAllOperationCompleted;
        
        private System.Threading.SendOrPostCallback getCamHasMotionOperationCompleted;
        
        private System.Threading.SendOrPostCallback isCamHasMotionOperationCompleted;
        
        private System.Threading.SendOrPostCallback getMotionOfCamAsPeriodOperationCompleted;
        
        private System.Threading.SendOrPostCallback getMotionOfAllAsPeriodOperationCompleted;
        
        private System.Threading.SendOrPostCallback getMotionOfCamAsDayOperationCompleted;
        
        private System.Threading.SendOrPostCallback getMotionOfCamAsHourOperationCompleted;
        
        private System.Threading.SendOrPostCallback getMotionOfCamAsLastOperationCompleted;
        
        private System.Threading.SendOrPostCallback getTimeOfLastMotionOperationCompleted;
        
        private System.Threading.SendOrPostCallback getFileUrlOfMotionOperationCompleted;
        
        private System.Threading.SendOrPostCallback getNumberOfMotionOperationCompleted;
        
        private System.Threading.SendOrPostCallback getNumberOfMotionInDayOperationCompleted;
        
        private System.Threading.SendOrPostCallback getNumberOfMotionInMonthOperationCompleted;
        
        private System.Threading.SendOrPostCallback getNumberOfMotionInYearOperationCompleted;
        
        private System.Threading.SendOrPostCallback getMyHostOperationCompleted;
        
        private System.Threading.SendOrPostCallback getConfigOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public VsService() {
            this.Url = global::Vs.Playback.Properties.Settings.Default.VsPlayback_VsService_VsService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event addCompletedEventHandler addCompleted;
        
        /// <remarks/>
        public event showFilesCompletedEventHandler showFilesCompleted;
        
        /// <remarks/>
        public event showTablesCompletedEventHandler showTablesCompleted;
        
        /// <remarks/>
        public event showCompletedEventHandler showCompleted;
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event getCamAllCompletedEventHandler getCamAllCompleted;
        
        /// <remarks/>
        public event getCamHasMotionCompletedEventHandler getCamHasMotionCompleted;
        
        /// <remarks/>
        public event isCamHasMotionCompletedEventHandler isCamHasMotionCompleted;
        
        /// <remarks/>
        public event getMotionOfCamAsPeriodCompletedEventHandler getMotionOfCamAsPeriodCompleted;
        
        /// <remarks/>
        public event getMotionOfAllAsPeriodCompletedEventHandler getMotionOfAllAsPeriodCompleted;
        
        /// <remarks/>
        public event getMotionOfCamAsDayCompletedEventHandler getMotionOfCamAsDayCompleted;
        
        /// <remarks/>
        public event getMotionOfCamAsHourCompletedEventHandler getMotionOfCamAsHourCompleted;
        
        /// <remarks/>
        public event getMotionOfCamAsLastCompletedEventHandler getMotionOfCamAsLastCompleted;
        
        /// <remarks/>
        public event getTimeOfLastMotionCompletedEventHandler getTimeOfLastMotionCompleted;
        
        /// <remarks/>
        public event getFileUrlOfMotionCompletedEventHandler getFileUrlOfMotionCompleted;
        
        /// <remarks/>
        public event getNumberOfMotionCompletedEventHandler getNumberOfMotionCompleted;
        
        /// <remarks/>
        public event getNumberOfMotionInDayCompletedEventHandler getNumberOfMotionInDayCompleted;
        
        /// <remarks/>
        public event getNumberOfMotionInMonthCompletedEventHandler getNumberOfMotionInMonthCompleted;
        
        /// <remarks/>
        public event getNumberOfMotionInYearCompletedEventHandler getNumberOfMotionInYearCompleted;
        
        /// <remarks/>
        public event getMyHostCompletedEventHandler getMyHostCompleted;
        
        /// <remarks/>
        public event getConfigCompletedEventHandler getConfigCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/add", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void add(string name, string url) {
            this.Invoke("add", new object[] {
                        name,
                        url});
        }
        
        /// <remarks/>
        public void addAsync(string name, string url) {
            this.addAsync(name, url, null);
        }
        
        /// <remarks/>
        public void addAsync(string name, string url, object userState) {
            if ((this.addOperationCompleted == null)) {
                this.addOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddOperationCompleted);
            }
            this.InvokeAsync("add", new object[] {
                        name,
                        url}, this.addOperationCompleted, userState);
        }
        
        private void OnaddOperationCompleted(object arg) {
            if ((this.addCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/showFiles", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL[] showFiles() {
            object[] results = this.Invoke("showFiles", new object[0]);
            return ((VsFileURL[])(results[0]));
        }
        
        /// <remarks/>
        public void showFilesAsync() {
            this.showFilesAsync(null);
        }
        
        /// <remarks/>
        public void showFilesAsync(object userState) {
            if ((this.showFilesOperationCompleted == null)) {
                this.showFilesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnshowFilesOperationCompleted);
            }
            this.InvokeAsync("showFiles", new object[0], this.showFilesOperationCompleted, userState);
        }
        
        private void OnshowFilesOperationCompleted(object arg) {
            if ((this.showFilesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.showFilesCompleted(this, new showFilesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/showTables", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] showTables() {
            object[] results = this.Invoke("showTables", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void showTablesAsync() {
            this.showTablesAsync(null);
        }
        
        /// <remarks/>
        public void showTablesAsync(object userState) {
            if ((this.showTablesOperationCompleted == null)) {
                this.showTablesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnshowTablesOperationCompleted);
            }
            this.InvokeAsync("showTables", new object[0], this.showTablesOperationCompleted, userState);
        }
        
        private void OnshowTablesOperationCompleted(object arg) {
            if ((this.showTablesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.showTablesCompleted(this, new showTablesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/show", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsFileURL show() {
            object[] results = this.Invoke("show", new object[0]);
            return ((VsFileURL)(results[0]));
        }
        
        /// <remarks/>
        public void showAsync() {
            this.showAsync(null);
        }
        
        /// <remarks/>
        public void showAsync(object userState) {
            if ((this.showOperationCompleted == null)) {
                this.showOperationCompleted = new System.Threading.SendOrPostCallback(this.OnshowOperationCompleted);
            }
            this.InvokeAsync("show", new object[0], this.showOperationCompleted, userState);
        }
        
        private void OnshowOperationCompleted(object arg) {
            if ((this.showCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.showCompleted(this, new showCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/HelloWorld", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getCamAll", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsCamera[] getCamAll() {
            object[] results = this.Invoke("getCamAll", new object[0]);
            return ((VsCamera[])(results[0]));
        }
        
        /// <remarks/>
        public void getCamAllAsync() {
            this.getCamAllAsync(null);
        }
        
        /// <remarks/>
        public void getCamAllAsync(object userState) {
            if ((this.getCamAllOperationCompleted == null)) {
                this.getCamAllOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetCamAllOperationCompleted);
            }
            this.InvokeAsync("getCamAll", new object[0], this.getCamAllOperationCompleted, userState);
        }
        
        private void OngetCamAllOperationCompleted(object arg) {
            if ((this.getCamAllCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getCamAllCompleted(this, new getCamAllCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void getCamHasMotionAsync(System.DateTime timeBegin, System.DateTime timeEnd) {
            this.getCamHasMotionAsync(timeBegin, timeEnd, null);
        }
        
        /// <remarks/>
        public void getCamHasMotionAsync(System.DateTime timeBegin, System.DateTime timeEnd, object userState) {
            if ((this.getCamHasMotionOperationCompleted == null)) {
                this.getCamHasMotionOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetCamHasMotionOperationCompleted);
            }
            this.InvokeAsync("getCamHasMotion", new object[] {
                        timeBegin,
                        timeEnd}, this.getCamHasMotionOperationCompleted, userState);
        }
        
        private void OngetCamHasMotionOperationCompleted(object arg) {
            if ((this.getCamHasMotionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getCamHasMotionCompleted(this, new getCamHasMotionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void isCamHasMotionAsync(string cameraID, System.DateTime timeBegin, System.DateTime timeEnd) {
            this.isCamHasMotionAsync(cameraID, timeBegin, timeEnd, null);
        }
        
        /// <remarks/>
        public void isCamHasMotionAsync(string cameraID, System.DateTime timeBegin, System.DateTime timeEnd, object userState) {
            if ((this.isCamHasMotionOperationCompleted == null)) {
                this.isCamHasMotionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnisCamHasMotionOperationCompleted);
            }
            this.InvokeAsync("isCamHasMotion", new object[] {
                        cameraID,
                        timeBegin,
                        timeEnd}, this.isCamHasMotionOperationCompleted, userState);
        }
        
        private void OnisCamHasMotionOperationCompleted(object arg) {
            if ((this.isCamHasMotionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.isCamHasMotionCompleted(this, new isCamHasMotionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void getMotionOfCamAsPeriodAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            this.getMotionOfCamAsPeriodAsync(timeBegin, timeEnd, cameraID, null);
        }
        
        /// <remarks/>
        public void getMotionOfCamAsPeriodAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, object userState) {
            if ((this.getMotionOfCamAsPeriodOperationCompleted == null)) {
                this.getMotionOfCamAsPeriodOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetMotionOfCamAsPeriodOperationCompleted);
            }
            this.InvokeAsync("getMotionOfCamAsPeriod", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, this.getMotionOfCamAsPeriodOperationCompleted, userState);
        }
        
        private void OngetMotionOfCamAsPeriodOperationCompleted(object arg) {
            if ((this.getMotionOfCamAsPeriodCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getMotionOfCamAsPeriodCompleted(this, new getMotionOfCamAsPeriodCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void getMotionOfAllAsPeriodAsync(System.DateTime timeBegin, System.DateTime timeEnd) {
            this.getMotionOfAllAsPeriodAsync(timeBegin, timeEnd, null);
        }
        
        /// <remarks/>
        public void getMotionOfAllAsPeriodAsync(System.DateTime timeBegin, System.DateTime timeEnd, object userState) {
            if ((this.getMotionOfAllAsPeriodOperationCompleted == null)) {
                this.getMotionOfAllAsPeriodOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetMotionOfAllAsPeriodOperationCompleted);
            }
            this.InvokeAsync("getMotionOfAllAsPeriod", new object[] {
                        timeBegin,
                        timeEnd}, this.getMotionOfAllAsPeriodOperationCompleted, userState);
        }
        
        private void OngetMotionOfAllAsPeriodOperationCompleted(object arg) {
            if ((this.getMotionOfAllAsPeriodCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getMotionOfAllAsPeriodCompleted(this, new getMotionOfAllAsPeriodCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMotionOfCamAsDay", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsMotion[] getMotionOfCamAsDay(string cameraID) {
            object[] results = this.Invoke("getMotionOfCamAsDay", new object[] {
                        cameraID});
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        public void getMotionOfCamAsDayAsync(string cameraID) {
            this.getMotionOfCamAsDayAsync(cameraID, null);
        }
        
        /// <remarks/>
        public void getMotionOfCamAsDayAsync(string cameraID, object userState) {
            if ((this.getMotionOfCamAsDayOperationCompleted == null)) {
                this.getMotionOfCamAsDayOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetMotionOfCamAsDayOperationCompleted);
            }
            this.InvokeAsync("getMotionOfCamAsDay", new object[] {
                        cameraID}, this.getMotionOfCamAsDayOperationCompleted, userState);
        }
        
        private void OngetMotionOfCamAsDayOperationCompleted(object arg) {
            if ((this.getMotionOfCamAsDayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getMotionOfCamAsDayCompleted(this, new getMotionOfCamAsDayCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMotionOfCamAsHour", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsMotion[] getMotionOfCamAsHour(string cameraID) {
            object[] results = this.Invoke("getMotionOfCamAsHour", new object[] {
                        cameraID});
            return ((VsMotion[])(results[0]));
        }
        
        /// <remarks/>
        public void getMotionOfCamAsHourAsync(string cameraID) {
            this.getMotionOfCamAsHourAsync(cameraID, null);
        }
        
        /// <remarks/>
        public void getMotionOfCamAsHourAsync(string cameraID, object userState) {
            if ((this.getMotionOfCamAsHourOperationCompleted == null)) {
                this.getMotionOfCamAsHourOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetMotionOfCamAsHourOperationCompleted);
            }
            this.InvokeAsync("getMotionOfCamAsHour", new object[] {
                        cameraID}, this.getMotionOfCamAsHourOperationCompleted, userState);
        }
        
        private void OngetMotionOfCamAsHourOperationCompleted(object arg) {
            if ((this.getMotionOfCamAsHourCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getMotionOfCamAsHourCompleted(this, new getMotionOfCamAsHourCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMotionOfCamAsLast", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VsMotion getMotionOfCamAsLast(string cameraID) {
            object[] results = this.Invoke("getMotionOfCamAsLast", new object[] {
                        cameraID});
            return ((VsMotion)(results[0]));
        }
        
        /// <remarks/>
        public void getMotionOfCamAsLastAsync(string cameraID) {
            this.getMotionOfCamAsLastAsync(cameraID, null);
        }
        
        /// <remarks/>
        public void getMotionOfCamAsLastAsync(string cameraID, object userState) {
            if ((this.getMotionOfCamAsLastOperationCompleted == null)) {
                this.getMotionOfCamAsLastOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetMotionOfCamAsLastOperationCompleted);
            }
            this.InvokeAsync("getMotionOfCamAsLast", new object[] {
                        cameraID}, this.getMotionOfCamAsLastOperationCompleted, userState);
        }
        
        private void OngetMotionOfCamAsLastOperationCompleted(object arg) {
            if ((this.getMotionOfCamAsLastCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getMotionOfCamAsLastCompleted(this, new getMotionOfCamAsLastCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getTimeOfLastMotion", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime getTimeOfLastMotion(string cameraId) {
            object[] results = this.Invoke("getTimeOfLastMotion", new object[] {
                        cameraId});
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public void getTimeOfLastMotionAsync(string cameraId) {
            this.getTimeOfLastMotionAsync(cameraId, null);
        }
        
        /// <remarks/>
        public void getTimeOfLastMotionAsync(string cameraId, object userState) {
            if ((this.getTimeOfLastMotionOperationCompleted == null)) {
                this.getTimeOfLastMotionOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetTimeOfLastMotionOperationCompleted);
            }
            this.InvokeAsync("getTimeOfLastMotion", new object[] {
                        cameraId}, this.getTimeOfLastMotionOperationCompleted, userState);
        }
        
        private void OngetTimeOfLastMotionOperationCompleted(object arg) {
            if ((this.getTimeOfLastMotionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getTimeOfLastMotionCompleted(this, new getTimeOfLastMotionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void getFileUrlOfMotionAsync(string motionID, System.DateTime motionDateTime) {
            this.getFileUrlOfMotionAsync(motionID, motionDateTime, null);
        }
        
        /// <remarks/>
        public void getFileUrlOfMotionAsync(string motionID, System.DateTime motionDateTime, object userState) {
            if ((this.getFileUrlOfMotionOperationCompleted == null)) {
                this.getFileUrlOfMotionOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetFileUrlOfMotionOperationCompleted);
            }
            this.InvokeAsync("getFileUrlOfMotion", new object[] {
                        motionID,
                        motionDateTime}, this.getFileUrlOfMotionOperationCompleted, userState);
        }
        
        private void OngetFileUrlOfMotionOperationCompleted(object arg) {
            if ((this.getFileUrlOfMotionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getFileUrlOfMotionCompleted(this, new getFileUrlOfMotionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void getNumberOfMotionAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            this.getNumberOfMotionAsync(timeBegin, timeEnd, cameraID, null);
        }
        
        /// <remarks/>
        public void getNumberOfMotionAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, object userState) {
            if ((this.getNumberOfMotionOperationCompleted == null)) {
                this.getNumberOfMotionOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetNumberOfMotionOperationCompleted);
            }
            this.InvokeAsync("getNumberOfMotion", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, this.getNumberOfMotionOperationCompleted, userState);
        }
        
        private void OngetNumberOfMotionOperationCompleted(object arg) {
            if ((this.getNumberOfMotionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getNumberOfMotionCompleted(this, new getNumberOfMotionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void getNumberOfMotionInDayAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            this.getNumberOfMotionInDayAsync(timeBegin, timeEnd, cameraID, null);
        }
        
        /// <remarks/>
        public void getNumberOfMotionInDayAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, object userState) {
            if ((this.getNumberOfMotionInDayOperationCompleted == null)) {
                this.getNumberOfMotionInDayOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetNumberOfMotionInDayOperationCompleted);
            }
            this.InvokeAsync("getNumberOfMotionInDay", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, this.getNumberOfMotionInDayOperationCompleted, userState);
        }
        
        private void OngetNumberOfMotionInDayOperationCompleted(object arg) {
            if ((this.getNumberOfMotionInDayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getNumberOfMotionInDayCompleted(this, new getNumberOfMotionInDayCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void getNumberOfMotionInMonthAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            this.getNumberOfMotionInMonthAsync(timeBegin, timeEnd, cameraID, null);
        }
        
        /// <remarks/>
        public void getNumberOfMotionInMonthAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, object userState) {
            if ((this.getNumberOfMotionInMonthOperationCompleted == null)) {
                this.getNumberOfMotionInMonthOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetNumberOfMotionInMonthOperationCompleted);
            }
            this.InvokeAsync("getNumberOfMotionInMonth", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, this.getNumberOfMotionInMonthOperationCompleted, userState);
        }
        
        private void OngetNumberOfMotionInMonthOperationCompleted(object arg) {
            if ((this.getNumberOfMotionInMonthCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getNumberOfMotionInMonthCompleted(this, new getNumberOfMotionInMonthCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
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
        public void getNumberOfMotionInYearAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID) {
            this.getNumberOfMotionInYearAsync(timeBegin, timeEnd, cameraID, null);
        }
        
        /// <remarks/>
        public void getNumberOfMotionInYearAsync(System.DateTime timeBegin, System.DateTime timeEnd, string cameraID, object userState) {
            if ((this.getNumberOfMotionInYearOperationCompleted == null)) {
                this.getNumberOfMotionInYearOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetNumberOfMotionInYearOperationCompleted);
            }
            this.InvokeAsync("getNumberOfMotionInYear", new object[] {
                        timeBegin,
                        timeEnd,
                        cameraID}, this.getNumberOfMotionInYearOperationCompleted, userState);
        }
        
        private void OngetNumberOfMotionInYearOperationCompleted(object arg) {
            if ((this.getNumberOfMotionInYearCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getNumberOfMotionInYearCompleted(this, new getNumberOfMotionInYearCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getMyHost", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getMyHost() {
            object[] results = this.Invoke("getMyHost", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getMyHostAsync() {
            this.getMyHostAsync(null);
        }
        
        /// <remarks/>
        public void getMyHostAsync(object userState) {
            if ((this.getMyHostOperationCompleted == null)) {
                this.getMyHostOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetMyHostOperationCompleted);
            }
            this.InvokeAsync("getMyHost", new object[0], this.getMyHostOperationCompleted, userState);
        }
        
        private void OngetMyHostOperationCompleted(object arg) {
            if ((this.getMyHostCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getMyHostCompleted(this, new getMyHostCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.vsa-srv.com/getConfig", RequestNamespace="http://www.vsa-srv.com/", ResponseNamespace="http://www.vsa-srv.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getConfig() {
            object[] results = this.Invoke("getConfig", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getConfigAsync() {
            this.getConfigAsync(null);
        }
        
        /// <remarks/>
        public void getConfigAsync(object userState) {
            if ((this.getConfigOperationCompleted == null)) {
                this.getConfigOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetConfigOperationCompleted);
            }
            this.InvokeAsync("getConfig", new object[0], this.getConfigOperationCompleted, userState);
        }
        
        private void OngetConfigOperationCompleted(object arg) {
            if ((this.getConfigCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getConfigCompleted(this, new getConfigCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.1433")]
    [System.SerializableAttribute()]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.1433")]
    [System.SerializableAttribute()]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.1433")]
    [System.SerializableAttribute()]
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void addCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void showFilesCompletedEventHandler(object sender, showFilesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class showFilesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal showFilesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsFileURL[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsFileURL[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void showTablesCompletedEventHandler(object sender, showTablesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class showTablesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal showTablesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void showCompletedEventHandler(object sender, showCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class showCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal showCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsFileURL Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsFileURL)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getCamAllCompletedEventHandler(object sender, getCamAllCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getCamAllCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getCamAllCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsCamera[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsCamera[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getCamHasMotionCompletedEventHandler(object sender, getCamHasMotionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getCamHasMotionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getCamHasMotionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsCamera[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsCamera[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void isCamHasMotionCompletedEventHandler(object sender, isCamHasMotionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class isCamHasMotionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal isCamHasMotionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getMotionOfCamAsPeriodCompletedEventHandler(object sender, getMotionOfCamAsPeriodCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getMotionOfCamAsPeriodCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getMotionOfCamAsPeriodCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsMotion[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsMotion[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getMotionOfAllAsPeriodCompletedEventHandler(object sender, getMotionOfAllAsPeriodCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getMotionOfAllAsPeriodCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getMotionOfAllAsPeriodCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsMotion[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsMotion[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getMotionOfCamAsDayCompletedEventHandler(object sender, getMotionOfCamAsDayCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getMotionOfCamAsDayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getMotionOfCamAsDayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsMotion[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsMotion[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getMotionOfCamAsHourCompletedEventHandler(object sender, getMotionOfCamAsHourCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getMotionOfCamAsHourCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getMotionOfCamAsHourCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsMotion[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsMotion[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getMotionOfCamAsLastCompletedEventHandler(object sender, getMotionOfCamAsLastCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getMotionOfCamAsLastCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getMotionOfCamAsLastCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsMotion Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsMotion)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getTimeOfLastMotionCompletedEventHandler(object sender, getTimeOfLastMotionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getTimeOfLastMotionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getTimeOfLastMotionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.DateTime Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.DateTime)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getFileUrlOfMotionCompletedEventHandler(object sender, getFileUrlOfMotionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getFileUrlOfMotionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getFileUrlOfMotionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VsFileURL Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VsFileURL)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getNumberOfMotionCompletedEventHandler(object sender, getNumberOfMotionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getNumberOfMotionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getNumberOfMotionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getNumberOfMotionInDayCompletedEventHandler(object sender, getNumberOfMotionInDayCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getNumberOfMotionInDayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getNumberOfMotionInDayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getNumberOfMotionInMonthCompletedEventHandler(object sender, getNumberOfMotionInMonthCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getNumberOfMotionInMonthCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getNumberOfMotionInMonthCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getNumberOfMotionInYearCompletedEventHandler(object sender, getNumberOfMotionInYearCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getNumberOfMotionInYearCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getNumberOfMotionInYearCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getMyHostCompletedEventHandler(object sender, getMyHostCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getMyHostCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getMyHostCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void getConfigCompletedEventHandler(object sender, getConfigCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getConfigCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getConfigCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
