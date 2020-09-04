import React from 'react'
import { Pagination } from 'semantic-ui-react'

const Paging:React.FC<{countPage:number, }> = ({countPage}) => {
    return (
        <Pagination onPageChange={()=>alert("dsdsd")} totalPages={countPage} />
    )
}

export default Paging
