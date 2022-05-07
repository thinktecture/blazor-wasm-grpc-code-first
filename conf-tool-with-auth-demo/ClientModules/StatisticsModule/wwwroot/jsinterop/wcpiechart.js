var interopJS = interopJS || {}

interopJS.charts = {
    dotNet: null,

    init: _ => {
        var chart = document.querySelector('wc-pie-chart');

        chart.addEventListener("selected", function (eventData) {
            console.log('### wc-pie-chart event fired!');
            console.log(eventData);

            dotNet.invokeMethodAsync("SetSelectedCountry", eventData.detail)
                .then(data => {
                    console.log("### wc-pie-chart was sent event details to .NET.");
                });
        });
    },

    register: dotNetReference => {
        dotNet = dotNetReference;
    }
}

window.interop = interopJS;
