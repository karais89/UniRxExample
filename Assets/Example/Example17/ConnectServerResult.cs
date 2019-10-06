using Photon.Realtime;

/// <summary> 
/// 서버 연결의 성공 여부 판정 클래스 
/// </summary> 
public abstract class ConnectServerResult { }

/// <summary> 
/// 성공 
/// </summary> 
public class ConnectServerSuccess : ConnectServerResult {  }

/// <summary> 
/// 실패 
/// </summary> 
public class ConnectServerFail : ConnectServerResult
{
    /// <summary> 
    /// 실패 원인 
    /// </summary> 
    public DisconnectCause Cause { get; }

    public ConnectServerFail(DisconnectCause cause) => Cause = cause;
}