# eNeg StrategyApp

## Description

StrategyApp is based on the different categories of negotiation strategies. The user defines his negotiation strategy, e.g. hardliner strategy or solution-oriented strategy and the App notifies, if the user doesn't act according the defined strategy. Also the StrategyApp suggest certain actions based on the course of the negotiation/offers exchange.

StrategyApp is a silverlight web based platform with desktop add-on extension, MVVM framework applied with n-tier layers.

* RIA Services
* Entity Framework
* Logging
* Excption Handling
* MEF

For more details please find the [Software Requirements Specification](https://github.com/ivconsult/eNeg/blob/master/eNeg%20Documentation/SRS_eNeg_Negotiation_Framework.docx), the [Technical Design Specification](https://github.com/ivconsult/eNeg/blob/master/eNeg%20Documentation/eNeg_TDS_KR.docx), the [Architecture](https://github.com/ivconsult/eNeg/blob/master/eNeg%20Documentation/eNEG%20Infrastructure%20logical%20Architecture.docx) and some videos explaining the uses cases of eNeg in [eNeg Documentation](https://github.com/ivconsult/eNeg/tree/master/eNeg%20Documentation).

## Features

* StrategyApp as already can be recognised by the name, supports the user to define his strategy or intentions during a negotiation. The App will advise the user through the course of the negotiation depending on the certian period and stage of the negotiation.
* Display the current status of the negotitation and check whether the negotiation position of the user and his offers/conversations with the counterparts follow his chosen strategy or not.
* Strategy status represented in red, yellow and green lights to be more eye catching
* Strategy App provides certain advice messages for the user to help him in finalizing negotiation steps and to enhance the negotation procedure.
* Strategy app is also used as an input factor for the [OfferApp](https://github.com/ivconsult/eNeg-OfferApp)


## Setting Development Environment

* A .NET Integrated Development Environment (IDE) such as Visual Studio or the free Visual Web Developer Express
* Install Microsoft Silverlight runtime for [windows](https://go.microsoft.com/fwlink/?LinkId=229324). (This is the runtime that’s required for Silverlight applications).
* Install [Silverlight Toolkit](https://silverlight.codeplex.com/releases/view/78435)
* Install [Silverlight SDK](https://www.microsoft.com/en-us/download/details.aspx?id=28359)
* Install [Silverlight Tools for VS 2010](https://www.microsoft.com/en-us/download/details.aspx?id=28358) (Optional)
* Install [Expression Blend](https://www.microsoft.com/en-eg/download/details.aspx?id=3062). This is a design tool that allows users to interact with Silverlight.

## References
### Following open-source projects were used:
* [Clog Client Logging](http://clog.codeplex.com) under [LGPL](http://clog.codeplex.com/license)
* [MVVM Light Toolkit](http://www.mvvmlight.net) under [MIT License](http://mvvmlight.codeplex.com/license)
* [iTextSharp](https://github.com/itext/itextsharp) under [AGPL](https://github.com/itext/itextsharp/blob/develop/LICENSE.md)
* [Rhino Mocks](https://github.com/ayende/rhino-mocks) under [BSD 3-clause "New" or "Revised" License](https://github.com/ayende/rhino-mocks/blob/master/license.txt)
* [silverPDF](https://silverpdf.codeplex.com/) under [MIT License](https://silverpdf.codeplex.com/license)
