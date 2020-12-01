using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace POP_TD3_001
{
    public partial class ucMachineList : DevExpress.XtraEditors.XtraUserControl
    {
        SettingBusiness business = new SettingBusiness();
        public ucMachineList()
        {
            InitializeComponent();
        }

        public void machine_Refresh()
        {
            //설비와 통신

            //DB로 값 불러오기
            DataTable pDataTable = business.Machine_Refresh(machine_name.Text);

            string equip_status = pDataTable.Rows[0]["RES_STS"].ToString();
            string conn_status = pDataTable.Rows[0]["RES_IF_STS"].ToString();


            switch (conn_status) // 연결상태
            {
                case "Off-Line": // Off-Line
                    machine_conn.Text = "Off-Line";
                    machine_conn.AppearanceItemCaption.ForeColor = Color.Crimson;
                    break;
                case "On-Line":// On-Line
                    machine_conn.Text = "On-Line";
                    machine_conn.AppearanceItemCaption.ForeColor = Color.MediumBlue;
                    break;
            }

            switch (equip_status) // 설비상태
            {
                case "생산중": // 생산중
                    machine_proc.Text = "생산중";
                    machine_proc.AppearanceItemCaption.ForeColor = Color.ForestGreen;
                    break;
                case "대기중":// 대기중
                    machine_proc.Text = "대기중";
                    machine_proc.AppearanceItemCaption.ForeColor = Color.LimeGreen;
                    break;
                case "Down":// down
                    machine_proc.Text = "Down";
                    machine_proc.AppearanceItemCaption.ForeColor = Color.Red;
                    //알람 보내기 -> Main Form 에서 처리
                    break;
            }

            //생산실적



        }

        public void Change_conn(string machine_name)
        {
            business.Change_Connection(machine_name);

            //switch (machine_conn.Text) // 연결상태
            //{
            //    case "On-Line":

            //        //db로 업데이트
            //        machine_conn.Text = "Off-Line";
            //        machine_conn.AppearanceItemCaption.ForeColor = Color.Crimson;
            //        break;

            //    case "Off-Line":

            //        //db로 업데이트
            //        machine_conn.Text = "On-Line";
            //        machine_conn.AppearanceItemCaption.ForeColor = Color.MediumBlue;
            //        break;
            //}

        }



        
    //    #region ○ using OPC.UaFx 부분
    //    ////namespace 목록
    //    using Opc.UaFx;
    //    using Opc.UaFx.Client;
    //    using System.Runtime.InteropServices;
    //    using System.Diagnostics;
    //    using System.Text.RegularExpressions;
    //    using Opc.Ua;
    //    using Opc.Ua.Client;

    //    #region ○ OpcClient 세팅
    //    /// <summary>
    //    /// AutoUpgradeEndpointPolicy = false
    //    /// AutoAcceptUntrustedCertificates = true
    //    /// </summary>
    //    /// <param name="HostIp">서버 IP</param>
    //    /// <param name="Port">서버 Port</param>
    //    /// <param name="ApplicationUri">Client ID</param>
    //    /// <returns></returns>
    //    private OpcClient OpcClientSetting(string HostIp, string Port, string ApplicationUri)
    //{
    //    try
    //    {
    //        OpcClient opcClient = new OpcClient("opc.tcp://" + HostIp + ":" + Port);
    //        opcClient.Security.AutoUpgradeEndpointPolicy = false;
    //        opcClient.Security.AutoAcceptUntrustedCertificates = true;
    //        opcClient.Configuration.ApplicationUri = ApplicationUri;
    //        return opcClient;
    //        #region ○ 보안정책 ( Security Policy )
    //        /*
    //        Aes128_Sha256_RsaOaep (not in .NET Framework, COM or Excel, i.e. only in .NET Standard)
    //        http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep

    //        Aes256_Sha256_RsaPss (not in .NET Framework, COM or Excel, i.e. only in .NET Standard)
    //        http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss

    //        Basic128Rsa15 (obsolete)
    //        http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15

    //        Basic256	
    //        http://opcfoundation.org/UA/SecurityPolicy#Basic256

    //        Basic256Sha256	
    //        http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256

    //        None	
    //        http://opcfoundation.org/UA/SecurityPolicy#None
    //         */
    //        #endregion

    //    }
    //    catch (Exception ex)
    //    {
    //        _tbValue.Items.Add("OpcClientSetting 오류 ! \r\n" + ex.Message.ToString());
    //        return new OpcClient();
    //    }

    //}
    //#endregion
    //#region ○ 연결부분
    ///// <summary>
    ///// 연결 실패시 true 반환
    ///// </summary>
    ///// <param name="_pclient">세팅이 완료된 OpcClient</param>
    //private bool DoConnect(Opc.UaFx.Client.OpcClient _pclient)
    //{
    //    bool _isFailed = true;

    //    try
    //    {
    //        _pClient = _pclient;
    //        _pClient.Connect();
    //    }
    //    catch (Exception ex)
    //    {
    //        _tbValue.Items.Add("Connection 오류 ! \r\n" + ex.Message.ToString());
    //        _isFailed = true;
    //    }/*string a = _pClient.ReadNode("").Value.ToString();*/

    //    _isFailed = _pClient.State.ToString() != "Connected" ? true : false;

    //    return _isFailed;
    //}
    ///// <summary>
    ///// 연결 상태를 확인하여 재연결 시도. Return : 실패여부 
    ///// </summary>
    ///// <param name="_pclient">Setting이 되어있는 OpcClient</param>
    //private bool CheckConnection(OpcClient _pclient)
    //{
    //    bool _isFailed = true;
    //    try
    //    {
    //        _isFailed = _pclient.State.ToString() != "Connected" ? DoConnect(_pclient) : false;
    //    }
    //    catch (Exception ex)
    //    {
    //        return true;
    //    }
    //    return _isFailed;

    //}
    //#endregion
    //#region ○ 데이터 Convert 함수 모음
    ///// <summary>
    ///// Value to String Converter.
    ///// 값이 없을 경우 "Value is null" 반환
    ///// </summary>
    ///// <param name="opcValue">유효한 opcValue</param>
    ///// <returns></returns>
    //private string OpcValueGetString(OpcValue opcValue)
    //{
    //    string ReturnStr = "";
    //    try
    //    {
    //        if (opcValue.Value != null)
    //        {
    //            if (opcValue.DataType.ToString() == "ExtensionObject")
    //            {
    //                ExpandedNodeId expandedNodeId = new ExpandedNodeId(opcValue.DataTypeId.ToString());
    //                ExtensionObject extensionObject = new ExtensionObject(expandedNodeId, opcValue.Value);
    //            }//ExtensionObject Convert 후 작업 필요시 사용예정.

    //            if (opcValue.Status.Code.ToString() == "Good")
    //            {
    //                ReturnStr = opcValue.Value.ToString();
    //                //Byte[] => UTF8 Endcoding => Replace"\0\0\0" to " " => Unescape
    //                switch (opcValue.Value.ToString())
    //                {
    //                    case "System.Byte[]":
    //                        ReturnStr = Regex.Unescape(Encoding.UTF8.GetString(opcValue.Value as byte[]).ToString()).Replace("\0\0\0", " ");
    //                        break;

    //                }
    //            }
    //            else
    //            {
    //                ReturnStr = "Read Node Quality is " + opcValue.Status.Code.ToString();
    //            }
    //        }
    //        else
    //        {
    //            ReturnStr = "Value is null";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ReturnStr = "Convert Failed " + ex.Message;
    //    }
    //    return ReturnStr;
    //}
    ///// <summary>
    ///// opcValue to String[] Converter.
    ///// 값이 없을 경우 "Value is null" 반환
    ///// </summary>
    ///// <param name="opcValue">유효한 opcValue</param>
    ///// <returns></returns>
    //private string[] OpcValueGetStringArr(OpcValue opcValue)
    //{
    //    string[] ReturnStrArr = { };
    //    try
    //    {
    //        if (opcValue.Value != null)
    //        {
    //            if (opcValue.DataType.ToString() == "ExtensionObject")
    //            {
    //                ExpandedNodeId expandedNodeId = new ExpandedNodeId(opcValue.DataTypeId.ToString());
    //                ExtensionObject extensionObject = new ExtensionObject(expandedNodeId, opcValue.Value);
    //            }//ExtensionObject Convert 후 작업 필요시 사용예정.

    //            if (opcValue.Status.Code.ToString() == "Good")
    //            {
    //                //Byte[] => UTF8 Endcoding => Replace"\0\0\0" to " " => Unescape
    //                switch (opcValue.Value.ToString())
    //                {
    //                    case "System.Byte[]":
    //                        ReturnStrArr = Regex.Unescape(Encoding.UTF8.GetString(opcValue.Value as byte[]).ToString()).Replace("\0\0\0", "splitPosition").Split(new string[] { "splitPosition" }, StringSplitOptions.None);
    //                        break;

    //                }
    //            }
    //            else
    //            {
    //                ReturnStrArr[0] = "Read Node Quality is " + opcValue.Status.Code.ToString();
    //            }
    //        }
    //        else
    //        {
    //            ReturnStrArr[0] = "Value is null";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ReturnStrArr[0] = "Convert Failed " + ex.Message;
    //    }
    //    return ReturnStrArr;
    //}

    //#endregion
    //#region OPC.Ua Nuget 함수
    //private ApplicationConfiguration CreateOpcUaAppConfiguration()
    //{
    //    var config = new ApplicationConfiguration()
    //    {
    //        ApplicationName = "MinimalClient",
    //        ApplicationType = ApplicationType.Client,
    //        SecurityConfiguration = new SecurityConfiguration
    //        {
    //            ApplicationCertificate = new CertificateIdentifier(),
    //            AutoAcceptUntrustedCertificates = true   //신뢰할 수 없는 인증서 허용
    //        },
    //        ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 }
    //    };

    //    config.Validate(ApplicationType.Client);

    //    //신뢰할 수 없는 인증서 허용
    //    if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
    //    {
    //        config.CertificateValidator.CertificateValidation += (s, e) =>
    //        {
    //            e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted);
    //        };
    //    }

    //    return config;
    //}
    //#endregion
    //#endregion
}
}
