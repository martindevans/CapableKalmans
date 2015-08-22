namespace CapableKalmans

module Kalman =

    type FilterParameters = {
        // The standard deviation of measurement error
        R: float
    }

    type FilterState = {
        Gain: float;
        ErrorCovariance: float;
        Estimation: float;
    }

    let DefaultFilterState () : FilterState =
        { Gain = 1.0; ErrorCovariance = 1.0; Estimation = 0.0; }
    
    let TimeUpdate (filter:FilterParameters, state:FilterState) : FilterState =
        state

    let MeasurementUpdate (filter:FilterParameters, state:FilterState, measurement:float) : FilterState = 
        let k = state.ErrorCovariance / (state.ErrorCovariance + filter.R)
        {
            Gain = k;
            Estimation = state.Estimation + k * (measurement - state.Estimation)
            ErrorCovariance = (1.0 - k) * state.ErrorCovariance
        }
