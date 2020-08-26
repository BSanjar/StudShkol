import React, { useContext, useEffect } from "react";
import { Grid, Segment, Form, Button, Label } from "semantic-ui-react";
import InputMask from "react-input-mask";
// import {
//   combineValidators,
//   isRequired,
//   composeValidators,
//   hasLengthGreaterThan,
// } from "revalidate";
import PromocodeStore from "../../../app/stores/PromocodeStore";
import { observer } from "mobx-react-lite";
import { history } from "../../..";
import LevelTestStore from "../../../app/stores/LevelTestStore";
const InputPromocode = () => {
 
    
  const promocodeStore = useContext(PromocodeStore);
  const { checkPromocode } = promocodeStore;
  
 

  var code="";

  const handleChangeCode= (e:any) => {
    code = e.target.value;
    checkPromocode(code.replace('-',''))  
  }
 

  const handleSubmit = () => {
    // const code2 = code;
    // console.log(code2)
    // console.log(code2.length)
    // //if(code.length>5)
      if(promocodeStore.finded){
        history.push("/chooseLevel");

    }
  };
  const levelTestsStore = useContext(LevelTestStore);

        useEffect(() => {
          levelTestsStore.loadAllLevelTests();
        }, [levelTestsStore]);
  return (
    <Grid>
      <Grid.Column width={10}>
        <Segment clearing>
          <Form onSubmit={handleSubmit}>
            <Label style={{color: promocodeStore.findedMessageColor}} content={promocodeStore.findedMessage} />
            <InputMask
              name="code"
              mask="999-999"
              maskChar={null}
              
              onChange={handleChangeCode}
              placeholder="000-000"
            />
            <Button
              style={{ marginTop: "1em" }}
              floated="right"
              positive
              type="submit"
              content="Войти"
            />
          </Form>
        </Segment>
      </Grid.Column>
    </Grid>
  );
};

export default observer(InputPromocode);
