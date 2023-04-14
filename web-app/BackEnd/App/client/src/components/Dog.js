import React from 'react';

function Dog(props){
    const data = props.data;
    return(
        <div>
            <p>
                {!data ? "Loading..." : data}
            </p>
        </div> 
    );
}

export default Dog;