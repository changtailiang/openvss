// nxoz	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// ioks	
// caws	 By downloading, copying, installing or using the software you agree to this license.
// qast	 If you do not agree to this license, do not download, install,
// ivov	 copy or use the software.
// zdtc	
// sszg	                          License Agreement
// prkm	         For OpenVSS - Open Source Video Surveillance System
// hmgk	
// nvxk	Copyright (C) 2007-2010, Prince of Songkla University, All rights reserved.
// gyqp	
// vlfv	Third party copyrights are property of their respective owners.
// kuxz	
// ytwk	Redistribution and use in source and binary forms, with or without modification,
// dmhq	are permitted provided that the following conditions are met:
// oedk	
// pkke	  * Redistribution's of source code must retain the above copyright notice,
// uifm	    this list of conditions and the following disclaimer.
// ydob	
// mdgg	  * Redistribution's in binary form must reproduce the above copyright notice,
// ndvu	    this list of conditions and the following disclaimer in the documentation
// tlnn	    and/or other materials provided with the distribution.
// pvgb	
// ohvc	  * Neither the name of the copyright holders nor the names of its contributors 
// ufal	    may not be used to endorse or promote products derived from this software 
// aaac	    without specific prior written permission.
// okau	
// evxz	This software is provided by the copyright holders and contributors "as is" and
// fack	any express or implied warranties, including, but not limited to, the implied
// ijqe	warranties of merchantability and fitness for a particular purpose are disclaimed.
// wwoy	In no event shall the Prince of Songkla University or contributors be liable 
// bdyr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// imhg	(including, but not limited to, procurement of substitute goods or services;
// dvfm	loss of use, data, or profits; or business interruption) however caused
// dtfj	and on any theory of liability, whether in contract, strict liability,
// ktju	or tort (including negligence or otherwise) arising in any way out of
// xgwo	the use of this software, even if advised of the possibility of such damage.
// ektl	
// pvoe	Intelligent Systems Laboratory (iSys Lab)
// lcbl	Faculty of Engineering, Prince of Songkla University, THAILAND
// ljms	Project leader by Nikom SUVONVORN
// nrwj	Project website at http://code.google.com/p/openvss/

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for VsDbConnect
/// </summary>
public class VsDbConnect
{
    private MySqlConnection conn;

    static string connString = "server=172.30.133.143;user id=root; password=; database=vsa-main; pooling=false";

	public VsDbConnect()
	{
        connecting();
		//
		// TODO: Add constructor logic here
		//
	}

    private MySqlConnection connecting()
    {
        if (conn != null)
            conn.Close();
        try
        {
            conn = new MySqlConnection("");
            conn.ConnectionString = connString;
            conn.Open(); 
        }
        catch //(MySqlException ex)
        {
            //MessageBox.Show("Error connecting to the server: " + ex.Message);
        }
        return conn;
    }
    public List<string> getFiles()
    {
        string t = getTables()[0].ToString();
        connecting();// ไม่ควรมี ควรเปลียนเป็น conn.open() แทน
        MySqlCommand comm = conn.CreateCommand();
        comm.CommandText = String.Format("select * from {0}",t);

        MySqlDataReader aReader = comm.ExecuteReader();
        //List<Files> list = new List<Files>();

        string[] dA = t.Split('_');
        string d = dA[4]+"-"+dA[3]+"-"+dA[2];

        List<String> allTable = new List<string>();
        while (aReader.Read())
        {
            //DateTime d = new DateTime();

            string cam = aReader["m_ip_camera"].ToString();
            string tim = aReader["m_date_start"].ToString();

            allTable.Add("ftp://" +"localhost/"+d+"/"+ HttpUtility.UrlEncode(cam) +"/"+ tim.Split()[1].Replace(':','-')+".avi") ;
            //allTable.Add((cam + "/" + tim.Split()[1])); 
        }
        return allTable;
    }
    public List<string> getTables()
    {
        connecting();
        MySqlCommand comm = conn.CreateCommand();
        comm.CommandText = String.Format("show tables");

        MySqlDataReader aReader = comm.ExecuteReader();
        //List<Files> list = new List<Files>();

        List<String> allTable = new List<string>();
        while (aReader.Read())
       {
           allTable.Add(aReader[0].ToString());
       }
        return allTable;
    }
}
