// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open CapableKalmans
open System
open System.Numerics;

[<EntryPoint>]
let main argv = 

    //Create a new Kalman filter with std dev 0.5
    let p : Kalman.FilterParameters = {
        R = 0.5
    }

    // Initialise default filter state
    let mutable k = Kalman.DefaultFilterState ()

    //Random number generator (this doesn't generate normally distributed values, so technically we're misusing the kalman filter here)
    let r = new Random()

    //Feed in random value between 0.5 and 1.5
    //Over time the filter will converge on 1.0 being the *true* underlying value
    while true do
        k <- Kalman.MeasurementUpdate (p, k, 0.5 + r.NextDouble ())
        k <- Kalman.TimeUpdate (p, k)
        printfn "%O" k.Estimation

    // Program return code (whatever)
    0
