export const cacheJWT = (jwt) => {
    return {type: 'SET_JWT', jwt: jwt}
  }
  
  export const clearJWT = () => {
    return {type: 'CLEAR_JWT', jwt: {}}
  }