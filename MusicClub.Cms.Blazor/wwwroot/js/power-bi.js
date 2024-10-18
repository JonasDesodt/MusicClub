function test(text) {
    console.log(text);
}

function embedPowerBIReportFromServer(embedUrl) {
    const models = window['powerbi-client'].models;
    const embedConfig = {
        type: 'report',
        embedUrl: embedUrl,
        tokenType: models.TokenType.,
        accessToken: '',
        settings: {
            panes: {
                filters: {
                    visible: true
                }
            }
        }
    };
    const reportContainer = document.getElementById('powerbi-report-container');
    const report = powerbi.embed(reportContainer, embedConfig);

    onReportLoaded(report); // Initialize filters handling when report loads
}
function onReportLoaded(report) {
    report.on('filtersApplied', function (/*event*/) {
        report.getFilters().then(function (filters) {
            // Send the applied filters to the Blazor app for saving
            saveFiltersToBlazor(filters);
        });
    });
}

function saveFiltersToBlazor(filters) {
    // Pass filters to Blazor via JS Interop
    DotNet.invokeMethodAsync('MusicClub.Cms.Blazor', 'SaveFilters', filters);
}

function applySavedFilters(report, savedFilters) {
    report.setFilters(savedFilters).then(function () {
        console.log('Filters applied');
    }).catch(function (errors) {
        console.error('Error applying filters:', errors);
    });
}