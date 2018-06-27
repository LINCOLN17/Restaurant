
document.addEventListener('DOMContentLoaded', function (event) {
    let view = new Vue({
        el: '#body-content',
        data: function (){
            return {
                dark: false,
                theme:
                    {
                        color: '##000000',
                        background: '#cccccc'
                    }
            };
        },
        methods: {
            changeTheme: function () {
                if (this.dark) {
                    this.theme =
                        {
                            color: '#bbbbbb',
                            background: '#171717'
                        };
                    console.log("dark active");
                }
                else {
                this.theme = {
                    color: '##000000',
                    background: '#cccccc'
                    };
                    console.log("white active");
                }
                
            }
        }

    });
});
