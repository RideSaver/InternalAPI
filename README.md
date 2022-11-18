# RideSaver Internal API

This repository contains the internal API of the RideSaver.

RideSaver uses [gRPC] (https://grpc.io) for the internal communications between the different services & web clients.

## Where are the Protos?
in the `protos` folder of the repository for the services utilizing gRPC protocols. 

## Services

### EstimateAPI 

The EstimateAPI service utilizes the gRPC protocols to make & recieve requests between the Uber & Lyft web-clients.

#### RPC services:

`GetEstimates(GetEstimatesRequest)` returns `stream EstimateModel`

Invoked when requesting a list of available estimates from either of the web clients, returns a list of gRPC-modeled Estimate instances.

`GetEstimateRefresh(GetEstimateRefreshRequest` returns `EstimateModel`

Invoked when requesting a refresh on a specific estimate instance, returns an instance of gRPC-modeled Estimate instance.

#### RPC models:

`GetEstimatesRequest`
- Properties: 
`LocationModel startPoint`
`LocationModel endPoint`
`repeated services`
`int32 seats`

`GetEstimateRefreshRequest`
- Properties:
`string estimate_id`

`EstimateModel`
- Represents an instance of the Estimate class.
- Properties:
`string estimate_id`
`google.protobuf.Timestamp createdTime`
`CurrencyModel priceDetails`
`int32 distance`
`repeated LocationModel wayPoints`
`int32 seats`
`string requestUrl`
`string displayName`

`LocationModel`
- Represents an instance of the Location class.
- Properties:
`double latitude`
`double longitude`
`double height`
`string planet`


`CurrencyModel`
- Represents an instance of the PriceCurrency class.
- Properties: 
`double price`
`string currency`

---

### RequestsAPI

The RequestAPI service utilizes the gRPC protocols to make & recieve requests between the Uber & Lyft web-clients involving ride-requests, ride ID retrievals, and cancellations.


#### RPC services:

`PostRideRequest(PostRideRequestModel)` returns `RideModel`

Invoked when attempting to post a new ride to create an instance of a request, returns an instance of gRPC-modeled Ride instance.

`GetRideRequest(GetRideRequestModel)` returns `RideModel`

Invoked when requesting an ID for the ride-request created earlier, returns an instance of gRPC-modeled Ride instance.

`DeleteRideRequest(DeleteRideRequestModel)` returns `CurrencyModel`

Invoked when attempting to cancel/delete a ride-request instance created earlier, returns an instance of gRPC-modeled PriceCurrency instance.

#### RPC models:

`PostRideRequestModel`
- Properties:
`string estimate_id`


`GetRideRequestModel`
- Properties:
`string ride_id`


`DeleteRideRequestModel`
- Properties:
`string ride_id`


`RideModel`
- Represents an instance of a Ride class
- Properties:
`string ride_id`
`google.protobuf.Timestamp estimatedTimeOfArrival`
`bool riderOnBoard`
`CurrencyModel price`
`DriverModel driver`
`Stage rideStage`
`LocationModel driverLocation`

`DriverModel`
- Represents an instance of a Driver class
- Properties: 
`string displayName`
`string licensePlate`
`string carPicture`
`string carDescription`
`string driverPronounciation`

`enum Stage`
- Represents the different stages of the ride-request
- Fields:
`STAGE_UNKNOWN`
`STAGE_PENDING`
`STAGE_ACCEPTED`
`STAGE_CANCELLED`
`STAGE_COMPLETED`

`LocationModel`
- Represents an instance of the Location class.
- Properties:
`double latitude`
`double longitude`
`double height`
`string planet`


`CurrencyModel`
- Represents an instance of the PriceCurrency class.
- Properties: 
`double price`
`string currency`
