using System;
using System.Collections;
using UnityEngine;

public class ExceptionUtils
{
	private static Hashtable hashTable = new Hashtable(128);

	public static void initValues()
	{
		Debug.Log("initValues()...");
		ExceptionUtils.hashTable.Add(361001, "系统内部错误");
		ExceptionUtils.hashTable.Add(361002, "推流地址申请失败");
		ExceptionUtils.hashTable.Add(361003, "推流地址续期失败");
		ExceptionUtils.hashTable.Add(361004, "节目开播失败");
		ExceptionUtils.hashTable.Add(361005, "节目结束失败");
		ExceptionUtils.hashTable.Add(361006, "uid不合法");
		ExceptionUtils.hashTable.Add(361007, "appid不合法");
		ExceptionUtils.hashTable.Add(361008, "获取当前节目信息失败");
		ExceptionUtils.hashTable.Add(361009, "该节目id不是待直播状态");
		ExceptionUtils.hashTable.Add(361010, "该节目id不是正在直播状态");
		ExceptionUtils.hashTable.Add(361011, "查询用户角色失败");
		ExceptionUtils.hashTable.Add(361012, "game_id不合法");
		ExceptionUtils.hashTable.Add(361013, "平台同时在线数达到上限阈值, 暂时不能新开播");
		ExceptionUtils.hashTable.Add(-361014, "请求超时");
		ExceptionUtils.hashTable.Add(361015, "参数无效");
		ExceptionUtils.hashTable.Add(361016, "拉取配置失败");
		ExceptionUtils.hashTable.Add(361017, "无效的登录态类型(非手Q)");
		ExceptionUtils.hashTable.Add(361018, "用户权限不足(被封禁)");
		ExceptionUtils.hashTable.Add(361019, "不在白名单");
		ExceptionUtils.hashTable.Add(1101, "网络状况不佳：上行带宽太小，上传数据受阻");
		ExceptionUtils.hashTable.Add(1102, "网络断连, 已启动自动重连 (自动重连连续失败超过三次会放弃)");
		ExceptionUtils.hashTable.Add(1103, "硬编码启动失败，采用软编码");
		ExceptionUtils.hashTable.Add(3001, "RTMP -DNS解析失败（会触发重试流程）");
		ExceptionUtils.hashTable.Add(3002, "RTMP服务器连接失败（会触发重试流程）");
		ExceptionUtils.hashTable.Add(3003, "RTMP服务器握手失败（会触发重试流程）");
		ExceptionUtils.hashTable.Add(-1301, "打开摄像头失败");
		ExceptionUtils.hashTable.Add(-1302, "打开麦克风失败");
		ExceptionUtils.hashTable.Add(-1303, "视频编码失败");
		ExceptionUtils.hashTable.Add(-1304, "音频编码失败");
		ExceptionUtils.hashTable.Add(-1305, "不支持的视频分辨率");
		ExceptionUtils.hashTable.Add(-1306, "不支持的音频采样率");
		ExceptionUtils.hashTable.Add(-1307, "网络断连,且经三次抢救无效,可以放弃治疗,更多重试请自行重启推流");
		ExceptionUtils.hashTable.Add(1, "密码错误");
		ExceptionUtils.hashTable.Add(2, "请输入验证码");
		ExceptionUtils.hashTable.Add(3, "长时间未操作，请重新登录");
		ExceptionUtils.hashTable.Add(4, "请输入正确验证码");
		ExceptionUtils.hashTable.Add(5, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(6, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(7, "账号异常，请登录QQ安全中心查看详情");
		ExceptionUtils.hashTable.Add(8, "无法识别的第三方");
		ExceptionUtils.hashTable.Add(9, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(10, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(11, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(12, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(14, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(15, "密码已过期，请重新登录");
		ExceptionUtils.hashTable.Add(16, "长时间未操作，请重新登录");
		ExceptionUtils.hashTable.Add(18, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(32, "您的帐号长期未登录已经冻结，建议您到http://zc.qq.com 申请一个新号码使用。");
		ExceptionUtils.hashTable.Add(33, "您的帐号由于存在安全风险，已启用临时登录限制，解除限制后即可正常登录。解除地址：\nhttp://aq.qq.com/xz");
		ExceptionUtils.hashTable.Add(40, "您的帐号暂被冻结，请点击http://aq.qq.com/007查看详情");
		ExceptionUtils.hashTable.Add(41, "您的QQ号码服务已到期，\n请尽快点击http://haoma.qq.com/expire/续费。\n固定电话拨打16885886可快捷续费");
		ExceptionUtils.hashTable.Add(42, "您的帐号已锁定，解锁请查看http://aq.qq.com/mp?id=1&source_id=2040");
		ExceptionUtils.hashTable.Add(43, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(44, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(48, "账号异常，请登录QQ安全中心查看详情");
		ExceptionUtils.hashTable.Add(113, "账号异常，请登录QQ安全中心查看详情");
		ExceptionUtils.hashTable.Add(128, "账号异常，请登录QQ安全中心查看详情");
		ExceptionUtils.hashTable.Add(129, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(154, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(130, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(131, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(132, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(133, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(134, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(160, "请输入短信验证码");
		ExceptionUtils.hashTable.Add(161, "请输入短信验证码");
		ExceptionUtils.hashTable.Add(162, "请输入短信验证码");
		ExceptionUtils.hashTable.Add(163, "请输入短信验证码");
		ExceptionUtils.hashTable.Add(901, "Quick verification mode does not support the operation");
		ExceptionUtils.hashTable.Add(256, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(263, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(264, "请输入正确用户名/密码");
		ExceptionUtils.hashTable.Add(272, "密码票据丢失或格式错误");
		ExceptionUtils.hashTable.Add(513, "当前网络不可用，请检查网络设置");
		ExceptionUtils.hashTable.Add(514, "网络超时，请稍后重试");
		ExceptionUtils.hashTable.Add(515, "网络超时，请稍后重试");
		ExceptionUtils.hashTable.Add(516, "当前网络不可用，请检查网络设置");
		ExceptionUtils.hashTable.Add(517, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(518, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(519, "当前网络不可用，请检查网络设置");
		ExceptionUtils.hashTable.Add(521, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(522, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(526, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(527, "网络繁忙，请稍后重试");
		ExceptionUtils.hashTable.Add(528, "操作超时，请稍后重试");
		ExceptionUtils.hashTable.Add(532, "网络连接不可用，请重新连接");
		ExceptionUtils.hashTable.Add(1907, "密码已修改，请重新输入密码");
		ExceptionUtils.hashTable.Add(4001, "该号码异常，存在安全风险，请定期修改密码");
		ExceptionUtils.hashTable.Add(4011, "该网络异常，请一段时间后再试");
		ExceptionUtils.hashTable.Add(4021, "该版本异常，请更新到最新版本");
		ExceptionUtils.hashTable.Add(4031, "该操作已过期");
		ExceptionUtils.hashTable.Add(583, string.Empty);
		ExceptionUtils.hashTable.Add(585, "登录态异常，请重新登录");
		ExceptionUtils.hashTable.Add(601, "解包失败");
	}

	public static string getErroMessage(int errorCode)
	{
		if (ExceptionUtils.hashTable.Keys.Count == 0)
		{
			ExceptionUtils.initValues();
		}
		if (ExceptionUtils.hashTable.ContainsKey(errorCode))
		{
			Debug.Log(ExceptionUtils.hashTable[errorCode].ToString());
			return ExceptionUtils.hashTable[errorCode].ToString();
		}
		return string.Empty;
	}
}
