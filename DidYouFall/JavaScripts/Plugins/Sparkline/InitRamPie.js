$(".RamPie").each(function () {
    var $this = $(this);
    $this.sparkline('html', {
        type: "pie",
        offset: "90",
        width: "40px",
        height: "40px",
        sliceColors: ['#f0360e', '#11a736'],
        tooltipFormat: '{{offset:offset}} ({{value}} MB)',
        tooltipValueLookups: {
            'offset': {
                0: 'Em Uso',
                1: 'Livre'
            }
        },
    });
});