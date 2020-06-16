$(document).ready(function () {
	var input = $('.input-validation-error:first');
	if (input) {
		input.focus();
	}
});


function getCityList() {
	var stateId = $("#StateId").val();
	debugger;
	$.ajax
	({
		url: '../Organization/GetCityListStateWise',
		type: 'POST',
		datatype: 'application/json',
		contentType: 'application/json',
		data: JSON.stringify({
			stateId: +stateId
		}),
		success: function (result) {
			$("#CityId").html("");
			$.each($.parseJSON(result), function (i, city) {
				$("#CityId").append($('<option></option>').val(city.CityId).html(city.CityName))
			})

		},
		error: function () {
			alert("Whooaaa! Something went wrong..")
		},
	});
}

function getAreaList() {
	otherCity();
	var cityId = $("#CityId").val();

	$.ajax
	({
		url: '../Organization/GetAreaListCityWise',
		type: 'POST',
		datatype: 'application/json',
		contentType: 'application/json',
		data: JSON.stringify({
			cityId: +cityId
		}),
		success: function (result) {
			$("#AreaId").html("");
			$.each($.parseJSON(result), function (i, area) {
				$("#AreaId").append($('<option></option>').val(area.AreaId).html(area.AreaName))
			})
		},
		error: function () {
			alert("Whooaaa! Something went wrong..")
		},
	});
}

function getOutstandingBalanceOfCustomer() {
	var customerId = $("#CustomerId").val();
	debugger;

	$.get('../PoultryBill/GetOutstandingBalanceOfCustomer', { customerId: +customerId }, function (data) {
		var OutstandingBalance = $("#OutstandingBalance");
		OutstandingBalance.val(parseFloat(data.replace("\"", "")));
	});
}

$("input[type='number']").keyup(function (e) {

	if (e.keyCode != 8 && e.keyCode != 9 && e.keyCode != 13) {
		var tempVal = $(this).val();
		var _isNumeric = $.isNumeric(tempVal);
		if (_isNumeric == false && e.keyCode != 189 && e.keyCode != 109) {
			alert('Value should be a valid numeric.');
		}

		else {
			if (parseFloat(tempVal) > 0) {
				tempVal = tempVal.replace(/^0+/, '');
				$(this).val(tempVal);
			}
		}
	}

	if ($(this).val().length > 18 && !$(this).hasClass("NoDecimal")) {
		alert('Value exceeds max limit.');
	}

});

function CalCurrentPoultryTotal() {
	var TotalQuantity = $("#TotalQuantity").val();
	var WeightInKg = $("#WeightInKg").val();
	var WeightInGram = $("#WeightInGram").val();
	var Weight = parseFloat(WeightInKg + "." + WeightInGram)
	var Rate = $("#Rate").val();
	var CurrentTotal = $("#CurrentTotal")
	var OutstandingBalance = $("#OutstandingBalance");
	var GrandTotal = $("#GrandTotal");
	var Deposit = $("#Deposit");
	var CurrentBalance = $("#CurrentBalance");

	var currentTotalValue = 0.00;
	var grandTotalValue = 0.00;

	if (OutstandingBalance.val().trim() == "" || OutstandingBalance.val() == null) {
		OutstandingBalance.val(0.00);
	}

	if (Weight.toString().trim() != "" || Weight != null)
	{
		if (Rate.trim() != "" || Rate != null) {
			currentTotalValue = (parseFloat(Rate) * Weight).toFixed(2)
			CurrentTotal.val(currentTotalValue);
		}
	}

	grandTotalValue = ((parseFloat(OutstandingBalance.val()) + parseFloat(currentTotalValue)).toFixed(2))
	GrandTotal.val(grandTotalValue)

	if (Deposit.val().trim() != "" || Deposit.val() != null)
	{
		if (parseFloat(Deposit.val()) > parseFloat(grandTotalValue)) {
			alert("Deposit amount should not greater than Grand total.");
			Deposit.val(grandTotalValue);
			return;
		}
		CurrentBalance.val((parseFloat(grandTotalValue) - parseFloat(Deposit.val())).toFixed(2));
	}
}

function getEndSubscriptionDate() {
	debugger;
	var StartDate = new Date($("#StartDate").val());
	var SubscriptionDays = $("#SubscriptionDays").val();
	var EndDate = $("#EndDate");

	StartDate.setDate(StartDate.getDate() + parseInt(SubscriptionDays));

	EndDate.val(StartDate.toISOString().split("T")[0]);

}

$("input[type='number']").change(function (e) {
	if (!$(this).hasClass("NoDecimal"))
		$(this).val(parseFloat($(this).val()).toFixed(2));

	if (($(this).val().trim() == "" || $(this).val() == null) && !$(this).hasClass("NoDecimal"))
		$(this).val("0.00")
});

$(".maxLimitTen").keyup(function (e) {
	if ($(this).val().length > 9) {
		$(this).val($(this).val().substring(0, 10));
		alert('Max limit for this field is 10');
	}
});
