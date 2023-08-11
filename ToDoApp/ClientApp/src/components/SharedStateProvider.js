import React, { createContext, useContext, useState } from 'react';

const SharedStateContext = createContext();

export function SharedStateProvider({ children }) {
    const [refreshFlag, setRefreshFlag] = useState(false);

    return (
        <SharedStateContext.Provider value={{ refreshFlag, setRefreshFlag }}>
            {children}
        </SharedStateContext.Provider>
    );
}

export function useSharedState() {
    return useContext(SharedStateContext);
}