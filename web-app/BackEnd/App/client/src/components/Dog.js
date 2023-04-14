import React from 'react';

function Dog(props){
    const data = props.data;
    return(
        <div>
            <button>
                {!data ? "Loading..." : data}
            </button>
        </div> 
    );
}

export default Dog;