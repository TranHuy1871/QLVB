//var vanban = (function () {

//	function vanban() {
//		this.LoadVBData = loadVBData;
//		this.loadTableView = loadTableView;
//	}


//	function loadVBData() {
//		var url = base_url + "/api/apiVB";

//		fetch(url)
//			.then(res => {
//				if (!res.ok) {
//					throw new Error(res.statusText);
//				}
//				return res.json();
//			})
//			.then(data => {

//				data = findAndReplaceJson(data, null, "");
//				const html = data.map(vb => {
//					return `
//					<tr id = "${vb.maVB}">
//						<td >${vb.maVB} </td>
//						<td >${vb.tenVB}</td>
//						<td >${vb.kieu}</td>
//						<td >${vb.ngayNhan}</td>
//						<td >${vb.nguoiKy}</td>
//						<td >${vb.ngayKy}</td>
//						<td >${vb.trangThai}</td>
//					</tr>
//					`
//				}).join("");
//				document.querySelector("#tb_VanBan > tbody").insertAdjacentHTML("afterbegin", html);
//				loadTableView();
//			})
//			.catch(error => {
//				console.log(error);
//			});
//	}

//	function findAndReplaceJson(object, value, replacevalue) {
//		for (var x in object) {
//			if (typeof object[x] == typeof {}) {
//				findAndReplaceJson(object[x], value, replacevalue);
//			}
//			if (object[x] == value) {
//				object[x] = "";
//			}
//		}
//		return object;
//	}

//	function loadTableView() {
//		var table_body = document.querySelector("#tb_VanBan tbody");
//		for (var i = 0; i < table_body.querySelectorAll("tr").length; i++) {
//			loadTableRow(i);
//		}
//	}

//	function loadTableRow(rowIndex) {
//		var row = document.querySelector("#tb_VanBan tbody").rows[rowIndex];

//		for (var j = 0; j < row.cells.length; j++) {
//			var val = row.cells[j].textContent;
//		}
//	}

//	return vanban;
//}());

$(document).ready(function () {
    $('#example').DataTable();
});