//var stock = (function () {
//	function stock() {
//		this.loadStockData = loadStockData;
//		this.loadTableView = loadTableView;
//	}

//	function loadStockData() {
//		var url = base_url + "/api/ApiStock";
//		fetch(url)
//			.then(res => {
//				if (!res.ok) {
//					throw new Error(res.statusText);
//				}
//				return res.json();
//			})
//			.then(data => {
//				data = findAndReplaceJson(data, null, "");
//				const html = data.map(stock => {
//					return `
//					<tr id = "${stock.ma}">
//						<td >${stock.ma} </td>
//						<td >${stock.tc}</td>
//						<td >${stock.tran}</td>
//						<td >${stock.san}</td>
//						<td >${stock.tongKL}</td>
//						<td >${stock.room}</td>
//						<td> <input type="submit" id="btn" class= "btn btn-primary" value="Edit" /> </td>
//					</tr>
//					`;
//				}).join("");
//				document.querySelector("#tb_Stock > tbody").insertAdjacentHTML("afterbegin", html);
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
//				// break; // uncomment to stop after first replacement
//			}
//		}
//		return object;
//	}

//	// tạo khung cho table
//	function loadTableView() {
//		var table_body = document.querySelector("#tb_Stock tbody");
//		//chọn <tbody> trong <table> tb_Stock r dùng vòng for để tạo các row
//		for (var i = 0; i < table_body.querySelectorAll("tr").length; i++) {
//			loadTableRow(i);
//		}
//	}

//	// đẩy data vào các ô tương ứng
//	function loadTableRow(rowIndex) {
//		var row = document.querySelector("#tb_Stock tbody").rows[rowIndex];
//		const tc = row.cells[1].textContent;
//		const tran = row.cells[2].textContent;
//		const san = row.cells[3].textContent;

//		for (var j = 4; j < row.cells.length; j++) {
//			var val = row.cells[j].textContent;
//		}
//	}

//	return stock;
//}());