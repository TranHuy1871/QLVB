var webSignalr = (function () {

	function webSignalr() {
		this.Start = start;
	}

	const connect = new signalR.HubConnectionBuilder()
		.withUrl("/webHub")
		.withAutomaticReconnect([0, 1000, 5000, null])
		.build();

	function start() {
		return connect.start().then(() => {
			init();
			connect.invoke("JoinGroupAsync", user).catch(function (err) {
				return console.error(err.toString());
			});
			connect.invoke("GetGroupInfor").catch(function (err) {
				return console.error(err.toString());
			});
		}).catch(function (err) {
			return console.error(err.toString());
		});
	}

	function init() {

		connect.on("GroupInfor", (connections, group) => {
			console.log(connections + "---" + group);
			document.getElementById("online-count").textContent = connections.toString();
			document.getElementById("connections-count").textContent = group.toString();
		});
	}

	return webSignalr;
}());

var signlr = new webSignalr();
signlr.Start();