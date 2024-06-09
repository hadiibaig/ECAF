$(document).ready(function () {
    // Main Menu 
    $('#mainMenuDrop').click(function () {
        $(this).toggleClass('active');
        $('.mainMenuDropBox').toggleClass('active');
    });
    $('.mainMenuCloseIcon').click(function () {
        $(this).closest('.mainMenuDropBox').removeClass('active');
    });
});

/* Updating Step Form */
$(document).ready(function () {



    function validateRequired() {
        let errors = [];
        $('.required').each(function () {
            var inputField = $(this);
            var fieldValue = inputField.val();
            if (fieldValue.length === 0) {
                errors.push(inputField.attr('name') + ' is required');
            }
        });
        return errors;
    }

    $(".next-btn").click(function (e) {

        e.preventDefault(); // Prevent default form submission
        var currentStep = $(this).closest("form");
        var nextStep = currentStep.next(".step");
        $(".steps .step-header").eq(currentStep.index() - 1).addClass("filled");
        currentStep.removeClass("active");
        nextStep.addClass("active");
    });

    $(".prev-btn").click(function(e) {
        e.preventDefault(); // Prevent default form submission
        var currentStep = $(this).closest("form");
        var prevStep = currentStep.prev(".step");
        $(".steps .step-header").eq(currentStep.index() - 2).removeClass("filled");
        currentStep.removeClass("active");
        prevStep.addClass("active");
    });

    $("#submitSiteCard").click(function (e) {
        e.preventDefault();

        let validate = validateRequired()
        if (validate.length > 0) {
            alert(validate[0]);
            return;
        }
        let customerDetails = {
            CustomerType: $('#SetupSiteCard_CustomerTypeId').val(), Name: $('#SetupSiteCard_CustomerBillingNameId').val(), InvoiceAddress: $('#SetupSiteCard_InvoicingAddressId').val(), PostCode: $('#SetupSiteCard_PostCodeId').val(),
            FinanceContactName: $('#SetupSiteCard_FinanceContactNameId').val(), FinanceContactNumber: $('#SetupSiteCard_FinanceContactNumberId').val(), FinanceContactEmail: $('#SetupSiteCard_FinanceContactEmailId').val()
        }
        let siteCardCharges = []
        $('.SiteCard_EmoloyeesContainer').each(function (i, obj) {
            if (obj) {
                var inputs = $(obj).find('input');
                let siteCardCharge = {}
                $(inputs).each(function (i, input) {
                    if (input) {
                        if ($(input).prop('name') == 'Position') {
                            siteCardCharge.Position = $(input).val() || ''
                        }
                        if ($(input).prop('name') == 'WeeklyHours') {
                            siteCardCharge.WeeklyHours = parseInt($(input).val() || '0')
                        }
                        if ($(input).prop('name') == 'PayRate') {
                            siteCardCharge.PayRate = parseInt($(input).val() || '0')
                        }
                        if ($(input).prop('name') == 'AdHocChargeRate') {
                            siteCardCharge.AdHocChargeRate = parseInt($(input).val() || '0')
                        }
                        if ($(input).prop('name') == 'EffectiveDate') {
                            siteCardCharge.EffectiveDate = $(input).val() || ''
                        }
                    }
                });
                siteCardCharges.push(siteCardCharge)
                siteCardCharge = {}
            }
        });
        let siteCardAmount = {
            BillingType: $('#SetupSiteCard_BillingTypeId').val(), AnnualCharge: $('#SetupSiteCard_AnnualChargeId').val(), AnnualBHCharge: $('#SetupSiteCard_AnnualBHChargeId').val(), TotalAmount: $('#SetupSiteCard_TotalAnnualId').val(),
            ChargePerPeriod: $('#SetupSiteCard_ChargePerPeriodId').val()

        }
        let siteCard = {
            Name: $('#SetupSiteCard_SiteNameId').val(), Address: $('#SetupSiteCard_SiteAddressId').val(), PostCode: $('#SetupSiteCard_PostCodeId_SD').val(),
            Customer: customerDetails, FacilitiesManager: { Name: $('#SetupSiteCard_FacilitiesMangaerNameId').val(), Number: $('#SetupSiteCard_FacilitiesMangaerNumberId').val(), Email: $('#SetupSiteCard_FacilitiesMangaerEmailId').val() },
            SiteCardCharge: siteCardCharges, SiteCardAmount: siteCardAmount
        }
        $.ajax({
            type: "POST",
            url: '/SiteCard/CreateSiteCard',
            data: JSON.stringify(siteCard),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data != '') {
                    window.location.href = '/SiteCard/SetupSiteSuccess?referenceNumber=' + data
                }
            },
            error: function (e) {

                console.log(e)
            }
        });
       
    });
    $("#submitUpdateSiteCard").click(function (e) {
        e.preventDefault();

        let validate = validateRequired()
        if (validate.length > 0) {
            alert(validate[0]);
            return;
        }
        let siteCardCodes = []
        $('.UpdateSiteCard_SiteCodeContainer').each(function (i, obj) {
            if (obj) {
                var inputs = $(obj).find('input');
                let siteCardCode = {}
                $(inputs).each(function (i, input) {
                    if (input) {
                        if ($(input).prop('name') == 'SiteCardCode') {
                            siteCardCode.SiteCardCode = $(input).val() || ''
                        }
                        if ($(input).prop('name') == 'SiteCardName') {
                            siteCardCode.SiteCardName = $(input).val() || ''
                        }
                    }
                });
                siteCardCodes.push(siteCardCode)
                siteCardCode = {}
            }
        });
        let siteCardCharges = []
        $('.SiteCard_EmoloyeesContainer').each(function (i, obj) {
            if (obj) {
                var inputs = $(obj).find('input');
                let siteCardCharge = {}
                $(inputs).each(function (i, input) {
                    if (input) {
                        if ($(input).prop('name') == 'Position') {
                            siteCardCharge.Position = $(input).val() || ''
                        }
                        if ($(input).prop('name') == 'SelectEmployees') {
                            siteCardCharge.EmployeeId = parseInt($(input).val() || '0')
                        }
                        if ($(input).prop('name') == 'PayRate') {
                            siteCardCharge.PayRate = parseInt($(input).val() || '0')
                        }
                        if ($(input).prop('name') == 'EffectiveDate') {
                            siteCardCharge.EffectiveDate = $(input).val() || ''
                        }
                    }
                });
                siteCardCharges.push(siteCardCharge)
                siteCardCharge = {}
            }
        });
        let siteCard = {
            SiteCardCharge: siteCardCharges, SiteCardCodes: siteCardCodes
        }
        $.ajax({
            type: "POST",
            url: '/SiteCard/UpdateSiteCard',
            data: JSON.stringify(siteCard),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data != '') {
                    window.location.href = '/SiteCard/SetupSiteSuccess?referenceNumber=' + data
                }
            },
            error: function (e) {

                console.log(e)
            }
        });

    });



    $("#submitTerminateSiteCard").click(function (e) {
        e.preventDefault();

        let validate = validateRequired()
        if (validate.length > 0) {
            alert(validate[0]);
            return;
        }     
        let siteCard = {
            SiteCardName: $('#TerminateSiteCard_SiteCardNameId').val(), SiteCardTerminatioDate: $('#TerminateSiteCard_TerminationDateId').val()
        }
        $.ajax({
            type: "POST",
            url: '/SiteCard/TerminateSiteCard',
            data: JSON.stringify(siteCard),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data != '') {
                    window.location.href = '/SiteCard/SetupSiteSuccess?referenceNumber=' + data
                }
            },
            error: function (e) {

                console.log(e)
            }
        });

    });
    $("#submitECAF").click(function (e) {
        e.preventDefault();

        let validate = validateRequired()
        if (validate.length > 0) {
            alert(validate[0]);
            return;
        }
        let siteCard = {
            Name: $('#ECAF_EmployeeNameId').val(), PinNumber: $('#ECAF_PINNumberId').val()?.toString(), NewContract: $("input[name='NewContract']").prop('checked'), SiteName: $('#ECAF_SiteNameId').val(),
            Position: $('#ECAF_PositionId').val(), Promotion: $("input[name='Promotion']").prop('checked'), WeeklyHours: $('#ECAF_WeeklyHoursId').val()?.toString(), Salary: $('#ECAF_PayRateId').val()?.toString(),
            BranchManager: $("input[name='BranchManager']").prop('checked'), HolidayManager: $("input[name='HolidayManager']").prop('checked'), HolidayYear: $('#ECAF_HolidayYearId').val(), HolidayRule: $('#ECAF_HolidayRuleId').val(),
            HolidayEntitlement: $('#ECAF_HolidayEntitlementId').val()?.toString(), EffectiveDate: $('#ECAF_EffectiveDateId').val()
        }
        $.ajax({
            type: "POST",
            url: '/SiteCard/CreateECAF',
            data: JSON.stringify(siteCard),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data != '') {
                    window.location.href = '/SiteCard/SetupSiteSuccess?referenceNumber=' + data
                }
            },
            error: function (e) {

                console.log(e)
            }
        });

    });
    $('#toggleAdHocCheckbox').change(function () {
        if (this.checked) {
            for (let i = 0; i < 3; i++) {
                var clonedDiv = $('.UpdateSiteCard_SiteCodeContainer').first().clone();
                $('#UpdateSiteCard_IsAdHocAttacthedContainer').append(clonedDiv);
            }
        }
        else {
            $('#UpdateSiteCard_IsAdHocAttacthedContainer .UpdateSiteCard_SiteCodeContainer').remove();
        }
    });
    $("#SiteCard_AddAdditionalEmployees").click(function (e) {
        e.preventDefault();
        var clonedDiv = $('#SiteCard_EmoloyeesContainer').clone();
        var inputs = $(clonedDiv).find('input');
        $(inputs).each(function (i, input) {
            if (input) {
                $(input).val('')
            }
        });
        $('#SiteCard_Container').append(clonedDiv);
        updateRemoveButton();

    });
    $('#SiteCard_RemoveEmployees').click(function (e) {
        e.preventDefault();
        $('#SiteCard_Container .SiteCard_EmoloyeesContainer').last().remove();
        updateRemoveButton();
    });

    function updateRemoveButton() {
        if ($('#SiteCard_Container .SiteCard_EmoloyeesContainer').length > 1) {
            $('#SiteCard_RemoveEmployees').show();
        } else {
            $('#SiteCard_RemoveEmployees').hide();
        }
    }
    updateRemoveButton();
});

// Assgined Form Accordion Form
$(document).ready(function(){
    $('.accordion-title').click(function(){
        const $content = $(this).next('.accordion-content');
        const $icon = $(this).find('.accordion-icon');
        $('.accordion-content').not($content).slideUp();
        $content.slideToggle();
        $icon.toggleClass('rotate');
    });
});

$(document).ready(function(){
    $('#detailBtn').click(function(){
        $('#commentPopup').css('display', 'block');
    });

    $('#commentPopupClose').click(function(){
        $('#commentPopup').css('display', 'none');
    });
});

//const checkbox = document.getElementById('attached_adhoc');
//    const popup = document.getElementById('attached_adhocPop');
//    const closeButton = document.getElementById('attached_adhocCont');

//    checkbox.addEventListener('change', function() {
//        if (this.checked) {
//            popup.style.display = 'block';
//        } else {
//            popup.style.display = 'none';
//        }
//    });

//    closeButton.addEventListener('click', function() {
//        popup.style.display = 'none';
//});


