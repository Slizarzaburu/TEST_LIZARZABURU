
$(window).on('load', function () {
    // Row Toggler
    // -----------------------------------------------------------------
    $('#demo-foo-row-toggler').footable();

    // Accordion
    // -----------------------------------------------------------------
    $('#demo-foo-accordion').footable().on('footable_row_expanded', function (e) {
        $('#demo-foo-accordion tbody tr.footable-detail-show').not(e.row).each(function () {
            $('#demo-foo-accordion').data('footable').toggleDetail(this);
        });
    });

    // Accordion
    // -----------------------------------------------------------------
    $('#demo-foo-accordion2').footable().on('footable_row_expanded', function (e) {
        $('#demo-foo-accordion2 tbody tr.footable-detail-show').not(e.row).each(function () {
            $('#demo-foo-accordion').data('footable').toggleDetail(this);
        });
    });


});
