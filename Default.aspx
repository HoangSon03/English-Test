<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <style>
        .container {
            position: relative;
        }

        .heading-title {
            width: 100%;
            margin: auto;
            display: block;
            text-align: center;
        }

            .heading-title img {
                width: 40%;
            }

        .content {
            position: absolute;
            height: 464.375px;
            width: 80%;
            /* margin: auto; */
            /* margin-top: 2%; */
            margin: 2% 0% 0% 10%;
        }

        .event__title {
            position: relative;
            margin: 0;
            font-size: 4rem;
            font-weight: 900;
            color: #fff;
            z-index: 1;
            overflow: hidden;
        }

            .event__title span {
                color: #ff022c;
            }

        .card-body {
            padding: 0rem;
            position: relative;
        }

        .card-header {
            font-family: cursive;
            font-size: 380%;
            color: #ff4d88;
            -webkit-text-stroke: 2px white;
            position: fixed;
            top: 37.5%;
            /*margin-left: 39.5%;*/
            background: transparent;
            position: absolute;
        }

        .button-53 {
            background-color: #ff5767;
            border: 0 solid #E5E7EB;
            box-sizing: border-box;
            color: #000000;
            display: flex;
            font-family: ui-sans-serif,system-ui,-apple-system,system-ui,"Segoe UI",Roboto,"Helvetica Neue",Arial,"Noto Sans",sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji";
            font-size: 1rem;
            font-weight: 700;
            justify-content: center;
            line-height: 1.75rem;
            padding: .75rem 1.65rem;
            position: relative;
            text-align: center;
            text-decoration: none #000000 solid;
            text-decoration-thickness: auto;
            width: 100%;
            max-width: 460px;
            position: relative;
            cursor: pointer;
            transform: rotate(-0.5deg);
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
        }

            .button-53:focus {
                outline: 0;
            }

            .button-53:after {
                content: '';
                position: absolute;
                border: 1px solid #000000;
                bottom: 4px;
                left: 4px;
                width: calc(100% - 1px);
                height: calc(100% - 1px);
            }

            .button-53:hover:after {
                bottom: 2px;
                left: 2px;
            }

        @media (min-width: 768px) {
            .button-53 {
                padding: .75rem 3rem;
                font-size: 1.25rem;
            }
        }

        a:hover {
            color: #ffffff;
            text-decoration: none;
        }

        @media (min-width: 992px) {
            .container {
                max-width: 100%;
            }
        }

        @media (max-width: 1450px) {
            .content {
                margin-top: 8%;
                width: 85%;
            }

            .card-header {
                font-size: 260%;
                top: 39.5%;
                /*margin-left: 35.8%;*/
            }
        }

        .notification {
            margin: 0 auto;
            text-align: center;
            padding-top: 2em;
            font-size: 24px;
            color: #B51A1A;
            font-weight: 500;
        }
    </style>
    <div class="main__list" style="display: block">
        <div class="container">
            <div class="heading-title">
                <image src="/images/English/list/englishexam.png"></image>
            </div>
            <div class="row content">
                <div class="col-lg-3 col-md-3 col-sm-6 col-12 sl sl-show mb-4 type1">
                    <div class="card card__tracnghiem">
                        <div class="card-body card-body__test">
                            <img class="rounded" src="/images/English/list/englishimg.jpg" />
                            <div class="card-header card-header__test">
                                Reading
                            </div>
                        </div>
                        <div class="card-footer card-footer__test">
                            <a class="button-53" href="/exercise-list-test-reading">Let's Go</a>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-12 sl sl-show mb-4 type1">
                    <div class="card card__tracnghiem">
                        <div class="card-body card-body__test">
                            <img class="rounded" src="/images/English/list/englishimg.jpg" />
                            <div class="card-header card-header__test">
                                Listening
                            </div>
                        </div>
                        <div class="card-footer card-footer__test">
                            <a class="button-53" href="/exercise-list-test-listening">Let's Go</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
