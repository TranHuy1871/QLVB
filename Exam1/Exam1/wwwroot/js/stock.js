var stock = (function () {

	function stock() {
		this.LoadStockData = loadStockData;		//trỏ tới func loadStockData
		this.loadTableView = loadTableView;		
		this.UpdateStock = updateStock;			
	}

	//Tới url /api/ApiStock và lấy data r trả về dưới dạng các cột
	function loadStockData() {
		var url = base_url + "/api/ApiStock";
		fetch(url)
			.then(res => {
				if (!res.ok) {
					throw new Error(res.statusText);
				}
				return res.json();
			})
			.then(data => {
				data = findAndReplaceJson(data, null, "");
				const html = data.map(stock => {
					return `
					<tr id = "${stock.ma}">
						<td class= "Ma">${stock.ma}</td>
						<td class="staticArea TC">${stock.tc}</td>
						<td class="staticArea Tran">${stock.tran}</td>
						<td class="staticArea San">${stock.san}</td>
						<td class= "MuaG3">${stock.muaG3}</td>
						<td class= "MuaKL3">${stock.muaKL3}</td>
						<td class= "MuaG2">${stock.muaG2}</td>
						<td class= "MuaKL2">${stock.muaKL2}</td>
						<td class= "MuaG1">${stock.muaG1}</td>
						<td class= "MuaKL1">${stock.muaKL1}</td>
						<td class="staticArea KhopLenhGia">${stock.khopLenhGia}</td>
						<td class="staticArea KhopLenhKL">${stock.khopLenhKL}</td>
						<td class="staticArea TileTangGiam">${stock.tileTangGiam}</td>
						<td class= "BanG1">${stock.banG1}</td>
						<td class= "BanKL1">${stock.banKL1}</td>
						<td class= "BanG2">${stock.banG2}</td>
						<td class= "BanKL2">${stock.banKL2}</td>
						<td class= "BanG3">${stock.banG3}</td>
						<td class= "BanKL3">${stock.banKL3}</td>
						<td class="staticArea TongKL">${stock.tongKL}</td>
						<td class="staticArea MoCua">${stock.moCua}</td>
						<td class="staticArea CaoNhat">${stock.caoNhat}</td>
						<td class="staticArea ThapNhat">${stock.thapNhat}</td>
						<td class="staticArea NNMua">${stock.nnMua}</td>
						<td class="staticArea NNBan">${stock.nnBan}</td>
						<td class="staticArea Room">${stock.room}</td>
					</tr>
					`;
				}).join("");
				document.querySelector("#tb_Stock > tbody").insertAdjacentHTML("afterbegin", html);
				loadTableView();
			})
			.catch(error => {
				console.log(error);
			});
	}

	function findAndReplaceJson(object, value, replacevalue) {
		for (var x in object) {
			if (typeof object[x] == typeof {}) {
				findAndReplaceJson(object[x], value, replacevalue);
			}
			if (object[x] == value) {
				object[x] = "";
				// break; // uncomment to stop after first replacement
			}
		}
		return object;
	}

	// tạo khung cho table
	function loadTableView() {
		var table_body = document.querySelector("#tb_Stock tbody");
		//chọn <tbody> trong <table> tb_Stock r dùng vòng for để tạo các row
		for (var i = 0; i < table_body.querySelectorAll("tr").length; i++) {
			loadTableRow(i);
		}
	}

	//update cả row
	function loadTableRow(rowIndex) {
		var row = document.querySelector("#tb_Stock tbody").rows[rowIndex];
		const tc = row.cells[1].textContent;
		const tran = row.cells[2].textContent;
		const san = row.cells[3].textContent;
		var color = "";

		//kiểm tra r thay đổi màu từng giá trị trong row
		for (var j = 4; j < row.cells.length; j++) {
			var val = row.cells[j].textContent;
			color = compareValue(tran, san, tc, val);
			updateCell(rowIndex, j, color);
		}
	}

	// so sánh value các cell trong table với tran, san, tc
	function compareValue(tran, san, tc, val) {
		if (val != '') {
			switch (val) {
				case tran:
					return '#e100f3'
					break;
				case san:
					return '#66c1cf'
					break;
				case tc:
					return '#d4ff31'
					break;
				default:
					if (tc > val) {
						return '#ff0a13';
					}
					if (tc < val) {
						return '#00ff00';
					}
			}
		}
		else
			return "";
    }

	//Sau  khi đã so sánh thì thực hiện chức năng thêm màu
	function updateCell(rowIndex, colIndex, color) {
		//console.log(rowIndex);
		var row = document.querySelector("#tb_Stock tbody").rows[rowIndex];
		switch (colIndex) {
			case 4:															
			case 6:															
			case 8:															
			case 13:														
			case 15:			
			case 17:								
				row.cells[colIndex + 1].style.color = color;
				break;
			case 20:
			case 21:
			case 22:
				break;

			//colum Khớp Lệnh
			case 10:
				row.cells[0].style.color = color;
				row.cells[colIndex + 1].style.color = color;
				row.cells[colIndex + 2].style.color = color;
				break;
			default:
				return;
		}
		row.cells[colIndex].style.color = color;
		//console.log("row idex: " + rowIndex + ", column index: " + colIndex + ", color: " + color);
    }

	//Update data
	function updateStock(data) {
		//var row = document.querySelector("#tb_Stock tbody > #" + data.ma);
		var arr = Object.values(data);	// array có dạng { [0] ; [ {[0];[1]} ] }
		var id = arr[0];

		var row = document.getElementById(id);

		var rowIndex = getRowIndexFromRowName(id)-2;

		// dùng vòng for trong arr[1] để xác định cellName và cellValue
		for (let i = 0; i < arr[1].length; i++) {
			var index = arr[1][i].cellName;

			var cellIndex = getCellIndexFromCellName(id, index);

			//Tìm ô cần update theo id và cellName xong gán = new value
			var cells = document.querySelector(`#${id} .${index}`);
			var val = cells.textContent = arr[1][i].cellValue;

			//thực hiện chức năng nháy ô khi dữ liệu thay đổi
			cells.classList.add("active");	// thêm class cho col được tìm thấy
			//sau 2s xóa bỏ class active cho col để quay về class cũ
			timeOut(cells);

			//đổi màu khi giá trị thay đổi

			const tc = row.cells[1].textContent;
			const tran = row.cells[2].textContent;
			const san = row.cells[3].textContent;

			//if (cellIndex == 1 || cellIndex == 2 || cellIndex ==3 ) {
			//}
			//var color = compareValue(tran, san, tc, val); // so sánh val với tc tran san
			//updateCell(rowIndex, cellIndex, color);	// thay đổi màu cho ô

			loadTableRow(rowIndex);

		}
	}

	function timeOut(cells) {
		setTimeout(function () {
			cells.classList.remove("active");
		}, 2000);
    }

	function getCellIndexFromCellName(rowName, cellName) {
		var tr = document.getElementById(rowName);
		var td = tr.querySelector("." + cellName);
		return td.cellIndex;
	}

	function getRowIndexFromRowName(rowName) {
		var tr = document.getElementById(rowName);
		return tr.rowIndex;
	}

	return stock;
}());


//signalr stock
var stockSignalr = (function (stockFunc) {

	function stockSignalr() {
		this.init = init;
	}

	function init() {
		const connect = new signalR.HubConnectionBuilder()
			.withUrl("/stockHub")
			.withAutomaticReconnect([0, 1000, 5000, null])
			.build();
		connect.start();
		connect.on("updateStock", function (data) {
			stockFunc.UpdateStock(data);
		});
	}
	return stockSignalr;
}(new stock()));

var signlr = new stockSignalr();
signlr.init();