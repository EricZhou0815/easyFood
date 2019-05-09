import {SET_JWT, CLEAR_JWT} from '../actions/userActionTypes'

const initialState = {
    loggedIn: false,
    jwt: {}
  }
  
  export default (state = initialState, action) => {
    switch (action.type) {
        case SET_JWT:
            return {
                ...state,
                jwt: {...action.jwt}, 
                loggedIn: true
            }
        case CLEAR_JWT:
            return {
                ...state,
                jwt: {...action.jwt}, 
                loggedIn: false
            }
        default:
            return state
    }
  }